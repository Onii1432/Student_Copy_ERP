$(document).ready(function () {


    $(function FillIteMaster() {

         alert('success');

        var ddlItemName = $("[id*=drpItemType]");
        var ddlItemCode = $("[id*=drpSearchItem]");

        // Variables for access methods from cs files
        var SearchItemUrl = "../JsMaster/ItemMaster_JS.aspx/SearchItemMaster";
        var updatedataurl = "../JsMaster/ItemMaster_JS.aspx/UpdateData";
        var savedataurl = "../JsMaster/ItemMaster_JS.aspx/SaveData";
        var DeleteItemUrl = "../JsMaster/ItemMaster_JS.aspx/DeleteData";

        //Fill the Item code and Item Name
        $.ajax({
           // type: "GET",
              type: "POST",
              url: "../JsMaster/ItemMaster_JS.aspx/FillItemMaster",
           // url: "http://localhost:50549/api/ItemMaster/TestAPI",
            data: '{name: "aalim"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });

            function OnSuccess(response) {
                var StateCodeList = response.d;
                alert(StateCodeList);
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
        //-----------------------------------------------------------------------------------------------------------

        // Code for bind all Controls by Button Click event
        $("#btnSearchItem").click(function () {
            var ItemCode = ddlItemCode.val();
            $.ajax({
                type: "POST",
                url: SearchItemUrl,
                data: "{'ItemCode':'" + ItemCode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
            function OnSuccess(response) {
                var ItemDtl = response.d;
                $("#txtItemCode").val(ItemDtl.ItemCode);
                $("#txtItemName").val(ItemDtl.ItemName);
                $("#txtItemManuf").val(ItemDtl.Manufacturer);
                $("#txtItemMaterial").val(ItemDtl.Material);
                $("#txtItemType").val(ItemDtl.ItemType);
                $("#txtItemSubType").val(ItemDtl.ItemSubType);
                $("#txtItemColor").val(ItemDtl.Color);
                $("#txtItemUOM").val(ItemDtl.UOM);
                $("#txtItemHSN").val(ItemDtl.HSNCODE);
                $("#txtGSTRate").val(ItemDtl.GSTRate);
                $("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
                $("#txtItemSellingCost").val(ItemDtl.SellingPrice);
            }
        });     // btnClick End

        // Code for Save data 

        $("#btnSaveItem").click(function () {

            var SaveData = {
                ItemCode: $("[id*=txtItemCode]").val(),
                ItemName: $("[id*=txtItemName]").val(),
                Manufacturer: $("#txtItemManuf").val(),
                Material: $("#txtItemMaterial").val(),
                ItemType: $("#txtItemType").val(),
                ItemSubType: $("#txtItemSubType").val(),
                Color: $("#txtItemColor").val(),
                UOM: $("#txtItemUOM").val(),
                HSNCODE: $("#txtItemHSN").val(),
                GSTRate: $("#txtGSTRate").val(),
                PurchaseCost: $("#txtItemPurchaseCost").val(),
                SellingPrice: $("#txtItemSellingCost").val(),
                Username: "Amol",
                LoginBranch: "Pune",
                RawMaterial: ""
            };

            $.ajax({
                type: "POST",
                url: savedataurl,
                data: JSON.stringify({ 'SaveData': SaveData }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
            function OnSuccess(response) {
                var ItemDtl = response.d;
                alert(ItemDtl);
                $("#txtItemCode").val(ItemDtl.ItemCode);
                $("#txtItemName").val(ItemDtl.ItemName);
                $("#txtItemManuf").val(ItemDtl.Manufacturer);
                $("#txtItemMaterial").val(ItemDtl.Material);
                $("#txtItemType").val(ItemDtl.ItemType);
                $("#txtItemSubType").val(ItemDtl.ItemSubType);
                $("#txtItemColor").val(ItemDtl.Color);
                $("#txtItemUOM").val(ItemDtl.UOM);
                $("#txtItemHSN").val(ItemDtl.HSNCODE);
                $("#txtGSTRate").val(ItemDtl.GSTRate);
                $("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
                $("#txtItemSellingCost").val(ItemDtl.SellingPrice);
            }

        }); // End of Save code

        // Code for Update

        $("#btnUpdate").click(function () {
            var UpdateData = {
                ItemCode: $("[id*=txtItemCode]").val(),
                ItemName: $("[id*=txtItemName]").val(),
                Manufacturer: $("#txtItemManuf").val(),
                Material: $("#txtItemMaterial").val(),
                ItemType: $("#txtItemType").val(),
                ItemSubType: $("#txtItemSubType").val(),
                Color: $("#txtItemColor").val(),
                UOM: $("#txtItemUOM").val(),
                HSNCODE: $("#txtItemHSN").val(),
                GSTRate: $("#txtGSTRate").val(),
                PurchaseCost: $("#txtItemPurchaseCost").val(),
                SellingPrice: $("#txtItemSellingCost").val(),
                Username: "Amol",
                LoginBranch: "Pune",
                RawMaterial: ""
            };
            $.ajax({
                type: "POST",
                url: updatedataurl,
                data: JSON.stringify({ 'UpdateData': UpdateData }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
            function OnSuccess(response) {
                var ItemDtl = response.d;
                alert(ItemDtl);
                $("#txtItemCode").val(ItemDtl.ItemCode);
                $("#txtItemName").val(ItemDtl.ItemName);
                $("#txtItemManuf").val(ItemDtl.Manufacturer);
                $("#txtItemMaterial").val(ItemDtl.Material);
                $("#txtItemType").val(ItemDtl.ItemType);
                $("#txtItemSubType").val(ItemDtl.ItemSubType);
                $("#txtItemColor").val(ItemDtl.Color);
                $("#txtItemUOM").val(ItemDtl.UOM);
                $("#txtItemHSN").val(ItemDtl.HSNCODE);
                $("#txtGSTRate").val(ItemDtl.GSTRate);
                $("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
                $("#txtItemSellingCost").val(ItemDtl.SellingPrice);
            }
        }); // End of Update Code

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

    });     // end of file

});