$(document).ready(function () {
    //alert('Its coming from Jquery');
    // Variables for access methods from cs files
            var url_FillItemMaster = API_URL + 'ItemMaster/FillItemMaster';
            var url_BindManufacturer = API_URL + 'ItemMaster/BindManfacturer';
            var url_BindColor = API_URL + 'ItemMaster/BindColor';
            var url_BindUom = API_URL + 'ItemMaster/BindUom';
            var url_BindCategory = API_URL + 'ItemMaster/BindCategory';
            var url_SearchItemMaster = API_URL + 'ItemMaster/SearchItemMaster';
            var url_SaveItemMaster = API_URL + 'ItemMaster/SaveData';
            var url_UpdateItemMaster = API_URL + 'ItemMaster/UpdateData';
            


    $(function FillItemMaster() {

        var ddlItemName = $("[id*=ItemName]");// Item Code It is Property  which is coming from View Item Master
        var ddlItemCode = $("[id*=ItemCode]");// Item Name It is model Property which is coming from View Item Master
        //Fill the Item code and Item Name
        $.ajax({
            type: "GET",
            //  type: "POST",
            // url: "../JsMaster/ItemMaster_JS.aspx/FillItemMaster",
            url: url_FillItemMaster,
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            //data: '{name: "aalim"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });

        function OnSuccess(response) {
            // alert("data came");
            var StateCodeList = response;
            //  alert(StateCodeList);
            $.each(StateCodeList, function () {
                ddlItemCode.append($("<option></option>").val(this['ItemCode']).html(this['ItemCode']));
                ddlItemName.append($("<option></option>").val(this['ItemCode']).html(this['ItemName']));
            });

        }

        //---------------------------------------------------------------------------------------------------------------

        // change itemcode and item name on the below code
        $(ddlItemName).change(function () {

            ddlItemCode.val(ddlItemName.val());
        });

        $(ddlItemCode).change(function () {

            ddlItemName.val(ddlItemCode.val());
        });


        //Validation are set on BtnSave Button
        //function clearInput()
        //{
        //    var getValue = document.getElementById("ItemFullName");
        //    if (getValue.value != "") {
        //        getValue.value = "";
        //    }
        //}

        $("#btnClear").click(function () {
            var getValue = document.getElementById("ItemFullName");
            if (getValue.value != "") {
                getValue.value = "";
            }
            
        });
        //Bindin Manufacturere Names-----------------------------------------------------------------------------------------------------------

        var ddManufacturere = $("[id*=ManufacturerId]"); //ManufacturereId  It is model Property which is coming from View Item Master
        $.ajax({
            type: "GET",
            //  type: "POST",
            url: url_BindManufacturer,
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            //data: '{name: "aalim"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessBindManufacturere,
            failure: function (response) {
                alert(response.d);
            }
        });

        function OnSuccessBindManufacturere(response) {
            // alert("data came");
            var StateCodeList = response;
            //  alert(StateCodeList);
            $.each(StateCodeList, function () {
                ddManufacturere.append($("<option></option>").val(this['ManufacturerId']).html(this['ManufacturerName']));
            });

        }

    //------End Of Binding of DropDown Manufacturer-----------////////

        //Bindin Color Names-----------------------------------------------------------------------------------------------------------

        var ddColor = $("[id*=ColourId]");//Color Id  It is model Property which is coming from View Item Master
        $.ajax({
            type: "GET",
            //  type: "POST",
            url: url_BindColor,
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            //data: '{name: "aalim"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessBindColor,
            failure: function (response) {
                alert(response.d);
            }
        });

        function OnSuccessBindColor(response) {
            // alert("data came");
            var StateCodeList = response;
            //  alert(StateCodeList);
            $.each(StateCodeList, function () {
                ddColor.append($("<option></option>").val(this['ColourId']).html(this['ColourName']));
            });

        }

    //------End Of Binding of color DropDown Manufacturer-----------////////
        //Bindin UOMaster dropdown Names-----------------------------------------------------------------------------------------------------------

        var ddUnitMaster = $("[id*=UnitId]");
        $.ajax({
            type: "GET",
            //  type: "POST",
            url: url_BindUom,
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            //data: '{name: "aalim"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessBindUnitMaster,
            failure: function (response) {
                alert(response.d);
            }
        });

        function OnSuccessBindUnitMaster(response) {
            // alert("data came");
            var StateCodeList = response;
            //  alert(StateCodeList);
            $.each(StateCodeList, function () {
                ddUnitMaster.append($("<option></option>").val(this['UnitId']).html(this['UnitName']));
            });

        }

    //------End Of Binding of Unit Master DropDown Manufacturer-----------////////
      //Bindin Category Master dropdown Names----------------
        var ddCategoryMaster = $("[id*=ItemCategoryId]");
        //var ddSubCategoryMaster = $("[id*=drpSubCategory]");

        $.ajax({
            type: "GET",
            //  type: "POST",
            url: url_BindCategory,
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            //data: '{name: "aalim"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessBindCategoryMaster,
            failure: function (response) {
                alert(response.d);
            }
        });

        function OnSuccessBindCategoryMaster(response) {
            // alert("data came");
            var StateCodeList = response;
            //  alert(StateCodeList);
            $.each(StateCodeList, function () {
                ddCategoryMaster.append($("<option></option>").val(this['CategoryId']).html(this['CategoryName']));
                //ddSubCategoryMaster.append($("<option></option>").val(this['CategoryId']).html(this['SubCategoryName']));
            });

        }


         //------End Of Binding of Category Master DropDown Manufacturer--------------------
        function BindSubCategory(CategoryId) {
            //$('#drpCategory').change(function () {
            //var CategoryId = $('#drpCategory').val();
            //alert(CategoryId);
            var obj = { CategoryId: CategoryId }
            $('#ItemSubCategoryId').empty();

            $.ajax({
                //type: "GET",
                type: "POST",
                url: API_URL +'ItemMaster/BindSubCategory?CategoryId=' + CategoryId,
                /*url: API_UR_URL + L +'ItemMaster/BindSubCategory'*/
                headers: {
                    "Authorization": "Basic " + Token,
                    "Content-Type": "application/json"
                },
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessBindSubCategoryMaster,
                failure: function (response) {
                    alert(response.d);
                }
            });

            //});


        }
        function OnSuccessBindSubCategoryMaster(response) {
            //alert("data came");
            var StateCodeList = response;
            //alert(StateCodeList);
            $('#ItemSubCategoryId').empty().append('<option selected="selected" value="0">-select-</option>');

            $.each(StateCodeList, function () {
                ddSubCategoryMaster.append($("<option></option>").val(this['SubCategoryId']).html(this['SubCategoryName']));
            });


        }

        //to get value from drop down category

        //var CategoryId = $('#drpCategory').val();
        var ddSubCategoryMaster = $("[id*=ItemSubCategoryId]");


        $('#ItemCategoryId').change(function () {
            BindSubCategory($('#ItemCategoryId').val());

        });


        // Code for bind all Controls by Button Click event
        $("#btnSearchItem").click(function () {

            //alert("btn serach clicked...");
            var ItemCode = ddlItemCode.val();
            //alert(ItemCode);

            $.ajax({
                type: "GET",
                url: url_SearchItemMaster + "?ItemCode=" + ItemCode,
                //url: url_SearchItemMaster + "?ItemCode=" + ItemCode,

                headers: {
                    "Authorization": "Basic" + Token,
                    "Content-Type": "application/json"
                },
                // data: "{'ItemCode':'" + ItemCode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessSearchItemMaster,
                failure: function (response) {
                    alert(response);
                }
            });
            function OnSuccessSearchItemMaster(response) {
                var ItemDtl = response;
                alert(ItemDtl);
                $("#ItemCodeNo").val(ItemDtl.ItemCode);
                $("#ItemFullName").val(ItemDtl.ItemName);
                $("#ManufacturerId").val(ItemDtl.ManufacturerId);
                $("#Material").val(ItemDtl.Material);
                $("#ItemCategoryId").val(ItemDtl.ItemCategoryId);
                BindSubCategory(ItemDtl.ItemCategoryId);
                $("#ItemSubCatogoryId").val(ItemDtl.ItemSubCategoryId);
                $("#ColourId").val(ItemDtl.ColourId);
                $("#UnitId").val(ItemDtl.UnitId);
                $("#HSNCODE").val(ItemDtl.HSNCODE);
                $("#GSTRate").val(ItemDtl.GSTRate);
                $("#PurchaseCost").val(ItemDtl.PurchaseCost);
                $("#SellingPrice").val(ItemDtl.SellingPrice);
            }
        });

        // btnClick End
        //Code for Save data

        $("#btnSaveItem").click(function () {
            alert($("#ItemSubCategoryId").val());
            //ItemSubCategoryId
            //var subCategoryId = $("[id*=ItemSubCatogoryId]");
            var SaveData = {
                //ItemCode: $("[id*=txtItemCode]").val(),
                ItemName: $("[id*=ItemFullName]").val(),
                ManufacturerId: $("#ManufacturerId").val(),
                Material: $("#Material").val(),
                ItemCategoryId: $("#ItemCategoryId").val(),
                ItemSubCategoryId: $("#ItemSubCategoryId").val(),
                ColourId: $("#ColourId").val(),
                UnitId: $("#UnitId").val(),
                HSNCODE: $("#HSNCODE").val(),
                GSTRate: $("#GSTRate").val(),
                PurchaseCost: $("#PurchaseCost").val(),
                SellingPrice: $("#SellingPrice").val(),

            };

            $.ajax({
                type: "POST",
                url: url_SaveItemMaster,
                headers: {
                    "Authorization": "Basic " + Token,
                    "Content-Type": "application/json"
                },
                data: JSON.stringify(SaveData),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessSaveItemMaster,
                failure: function (response) {
                    alert(response.d);
                }
            });
            function OnSuccessSaveItemMaster(response) {
                var ItemDtl = response;
                alert(ItemDtl);
                //$("#txtItemCode").val(ItemDtl.ItemCode);
                $("#ItemFullName").val(ItemDtl.ItemName);
                $("#ManufacturerId").val(ItemDtl.ManufacturerId);
                $("#Material").val(ItemDtl.Material);
                $("#ItemCategoryId").val(ItemDtl.ItemCategoryId);
                $("#ItemSubCategoryId").val(ItemDtl.ItemSubCategoryId);
                $("#ColourId").val(ItemDtl.ColourId);
                $("#UnitId").val(ItemDtl.UnitId);
                $("#HSNCODE").val(ItemDtl.HSNCODE);
                $("#GSTRate").val(ItemDtl.GSTRate);
                $("#PurchaseCost").val(ItemDtl.PurchaseCost);
                $("#SellingPrice").val(ItemDtl.SellingPrice);
            }

        });
        // End of Save code

        // Code for Update
        
        $("#btnUpdate").click(function () {
            //alert('update button is clicked');
            var UpdateData = {
                ItemCode: $("[id*=ItemCodeNo]").val(),
                ItemName: $("[id*=ItemFullName]").val(),
                ManufacturerId: $("#ManufacturerId").val(),
                Material: $("#Material").val(),
                ItemCategoryId: $("#ItemCategoryId").val(),
                ItemSubCategoryId: $("#ItemSubCategoryId").val(),
                ColourId: $("#ColourId").val(),
                UnitId: $("#UnitId").val(),
                HSNCODE: $("#HSNCODE").val(),
                GSTRate: $("#GSTRate").val(),
                PurchaseCost: $("#PurchaseCost").val(),
                SellingPrice: $("#SellingPrice").val(),
            };
            $.ajax({
                type: "POST",
                url: url_UpdateItemMaster,
                headers: {
                    "Authorization": "Basic " + Token,
                    "Content-Type": "application/json"
                },
                data: JSON.stringify(UpdateData),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessUpdateItemMaster,
                failure: function (response) {
                    alert(response.d);
                }
            });
            function OnSuccessUpdateItemMaster(response) {
                var ItemDtl = response;
                alert(ItemDtl);
                $("#txtItemCode").val(ItemDtl.ItemCode);
                $("#ItemFullName").val(ItemDtl.ItemName);
                $("#ManufacturerId").val(ItemDtl.ManufacturerId);
                $("#Material").val(ItemDtl.Material);
                $("#ItemCategoryId").val(ItemDtl.ItemCategoryId);
                $("#ItemSubCategoryId").val(ItemDtl.ItemSubCategoryId);
                $("#ColourId").val(ItemDtl.ColourId);
                $("#UnitId").val(ItemDtl.UnitId);
                $("#HSNCODE").val(ItemDtl.HSNCODE);
                $("#GSTRate").val(ItemDtl.GSTRate);
                $("#PurchaseCost").val(ItemDtl.PurchaseCost);
                $("#SellingPrice").val(ItemDtl.SellingPrice);
            }
        });

        // End of Update Code



    });


});