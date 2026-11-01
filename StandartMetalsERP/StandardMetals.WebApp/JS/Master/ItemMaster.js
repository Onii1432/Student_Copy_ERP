

$(document).ready(function () {
    //alert('its coming form jquery');
        // Variables for access methods from cs files
            var url_FillItemMaster = API_URL + 'ItemMaster/FillItemMaster';
            var url_BindManufacturer = API_URL + 'ItemMaster/BindManfacturer';
            var url_BindColor = API_URL + 'ItemMaster/BindColor';
            var url_BindUom = API_URL + 'ItemMaster/BindUom';
            var url_BindCategory = API_URL + 'ItemMaster/BindCategory';
            var url_SearchItemMaster = API_URL + 'ItemMaster/SearchItemMaster';
            var url_SaveItemMaster = API_URL + 'ItemMaster/SaveData';
            var url_UpdateItemMaster = API_URL + 'ItemMaster/UpdateData';

    // above varibales are used to store URL
    
    $(function FillIteMaster() {

        var ddlItemName = $("[id*=drpItemType]");
        var ddlItemCode = $("[id*=drpSearchItem]");
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
        //Bindin Manufacturere Names-----------------------------------------------------------------------------------------------------------

        var ddManufacturere = $("[id*=drpManufacturer]");
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

        var ddColor = $("[id*=drpColor]");
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

        var ddUnitMaster = $("[id*=drpUOM]");
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
        //Bindin Category Master dropdown Names-----------------------------------------------------------------------------------------------------------

        var ddCategoryMaster = $("[id*=drpCategory]");
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


        

    //------End Of Binding of Category Master DropDown Manufacturer-----------////////
        //Binding  SubCategory Master dropdown Names-----------------------------------------------------------------------------------------------------------
//alim sir function

        //callMe = function () {
        //    alert('hello');
        //}

        BindSubCategory = function(CategoryId) {
            //$('#drpCategory').change(function () {
                //var CategoryId = $('#drpCategory').val();
                //alert(CategoryId);
                var obj = { CategoryId: CategoryId }
                $('#drpSubCategory').empty();

                $.ajax({
                    //type: "GET",
                    type: "POST",
                    url: API_URL + 'ItemMaster/BindSubCategory?CategoryId=' + CategoryId,
                    /*url: API_URL +'ItemMaster/BindSubCategory'*/
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
            //$('#drpSubCategory').empty().append('<option selected="selected" value="0">-select-</option>');
            $.each(StateCodeList, function () {
                ddSubCategoryMaster.append($("<option></option>").val(this['SubCategoryId']).html(this['SubCategoryName']));
            });


        }

        //to get value from drop down category

        //var CategoryId = $('#drpCategory').val();
        var ddSubCategoryMaster = $("[id*=drpSubCategory]");


        $('#drpCategory').change(function () {
            BindSubCategory($('#drpCategory').val());
            
        });

        
    //------End Of Binding of Category Master DropDown Manufacturer-----------////////

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
                $("#txtItemCode").val(ItemDtl.ItemCode);
                $("#txtItemName").val(ItemDtl.ItemName);
                $("#drpManufacturer").val(ItemDtl.ManufacturerId);
                $("#txtItemMaterial").val(ItemDtl.Material);
                $("#drpCategory").val(ItemDtl.ItemCategoryId);
                BindSubCategory(ItemDtl.ItemCategoryId);
                $("#drpSubCategory").val(ItemDtl.ItemSubCategoryId);
                $("#drpColor").val(ItemDtl.ColourId);
                $("#drpUOM").val(ItemDtl.UnitId);
                $("#txtItemHSN").val(ItemDtl.HSNCODE);
                $("#txtGSTRate").val(ItemDtl.GSTRate);
                $("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
                $("#txtItemSellingCost").val(ItemDtl.SellingPrice);
            }
        });     // btnClick End



        //Code for Save data

        $("#btnSaveItem").click(function () {
            
            var SaveData = {
                //ItemCode: $("[id*=txtItemCode]").val(),
                ItemName: $("[id*=txtItemName]").val(),
                ManufacturerId: $("#drpManufacturer").val(),
                Material: $("#txtItemMaterial").val(),
                ItemCategoryId: $("#drpCategory").val(),
                ItemSubCategoryId: $("#drpSubCategory").val(),
                ColourId: $("#drpColor").val(),
                UnitId: $("#drpUOM").val(),
                HSNCODE: $("#txtItemHSN").val(),
                GSTRate: $("#txtGSTRate").val(),
                PurchaseCost: $("#txtItemPurchaseCost").val(),
                SellingPrice: $("#txtItemSellingCost").val(),
                
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
                $("#txtItemName").val(ItemDtl.ItemName);
                $("#drpManufacturer").val(ItemDtl.ManufacturerId);
                $("#txtItemMaterial").val(ItemDtl.Material);
                $("#drpCategory").val(ItemDtl.ItemCategoryId);
                $("#drpSubCategory").val(ItemDtl.ItemSubCategoryId);
                $("#drpColor").val(ItemDtl.ColourId);
                $("#drpUOM").val(ItemDtl.UnitId);
                $("#txtItemHSN").val(ItemDtl.HSNCODE);
                $("#txtGSTRate").val(ItemDtl.GSTRate);
                $("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
                $("#txtItemSellingCost").val(ItemDtl.SellingPrice);
            }

        });
        // End of Save code

        // Code for Update

        $("#btnUpdate").click(function () {
            //alert('update button is clicked');
            var UpdateData = {
                ItemCode: $("[id*=txtItemCode]").val(),
                ItemName: $("[id*=txtItemName]").val(),
                ManufacturerId: $("#drpManufacturer").val(),
                Material: $("#txtItemMaterial").val(),
                ItemCategoryid: $("#drpCategory").val(),
                ItemSubCategoryid: $("#drpSubCategory").val(),
                ColourId: $("#drpColor").val(),
                UnitId: $("#drpUOM").val(),
                HSNCODE: $("#txtItemHSN").val(),
                GSTRate: $("#txtGSTRate").val(),
                PurchaseCost: $("#txtItemPurchaseCost").val(),
                SellingPrice: $("#txtItemSellingCost").val()
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
                $("#txtItemName").val(ItemDtl.ItemName);
                $("#drpManufacturer").val(ItemDtl.ManufacturerId);
                $("#txtItemMaterial").val(ItemDtl.Material);
                $("#drpCategory").val(ItemDtl.ItemCategoryId);
                $("#drpSubCategory").val(ItemDtl.ItemSubCategoryId);
                $("#drpColor").val(ItemDtl.ColourId);
                $("#drpUOM").val(ItemDtl.UnitId);
                $("#txtItemHSN").val(ItemDtl.HSNCODE);
                $("#txtGSTRate").val(ItemDtl.GSTRate);
                $("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
                $("#txtItemSellingCost").val(ItemDtl.SellingPrice);
            }
        });

        // End of Update Code

        // Code for Delete Record

        $("#btnCancelItem").click(function () {
            var IitemCode = ddlItemCode.val();
            $.ajax({
                type: "POST",
                url: DeleteItemUrl,
                data: "{'itemcode' : '" + ItemCode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

        });

    });
    // end of file

});