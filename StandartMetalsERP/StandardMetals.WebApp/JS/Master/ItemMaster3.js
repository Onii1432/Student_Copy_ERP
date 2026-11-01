$(document).ready(function () {
    //alert('its working');

    //Uri to call APi
    //var url_FillItemMaster = API_URL + 'ItemMaster/FillItemMaster';
    $('#ItemCategoryId').change(function () {
        BindSubCategory($('#ItemCategoryId').val());

    });


    function BindSubCategory(CategoryId) {
        //$('#drpCategory').change(function () {
        //var CategoryId = $('#drpCategory').val();
        //alert(CategoryId);
        var obj = { CategoryId: CategoryId }
        $('#ItemSubCategoryId').empty();

        $.ajax({
            //type: "GET",
            type: "POST",
            url: "/Master/GetItemSubCategory?CategoryId=" + CategoryId,
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


    var ddSubCategoryMaster = $("[id*=ItemSubCategoryId]");
    
    function OnSuccessBindSubCategoryMaster(response) {
        //alert("data came");
        var StateCodeList = response;
        //alert(StateCodeList);
        $('#ItemSubCategoryId').empty().append('<option selected="selected" value="0">-select-</option>');
        $.each(StateCodeList, function () {
            ddSubCategoryMaster.append($("<option></option>").val(this['SubCategoryId']).html(this['SubCategoryName']));
        });


    }

    //code to bind Item Code Against Item Name

    var ddlItemCode = $("[id*=ItemCode]");// Item Name It is model Property which is coming from View Item Master
    var ddlItemName = $("[id*=ItemName]");// Item Code It is Property  which is coming from View Item Master
//Fill the Item code and Item Name
    $.ajax({
        type: "POST",
        //  type: "POST",
        // url: "../JsMaster/ItemMaster_JS.aspx/FillItemMaster",
        url: "/Master/FillItemMaster",
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

    // End of the Binding of Item Code And Item Name

    //code to Fill Item Master
    $("#btnSearchItem").click(function () {

        //alert("btn serach clicked...");
        var ItemCode = ddlItemCode.val();
        //alert(ItemCode);

        $.ajax({
            type: "POST",
            url: "/Master/SearchItemMaster?ItemCode=" + ItemCode,
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
            $("#ItemSubCategoryId").val(ItemDtl.ItemSubCategoryId);
            $("#ColourId").val(ItemDtl.ColourId);
            $("#UnitId").val(ItemDtl.UnitId);
            $("#HSNCODE").val(ItemDtl.HSNCODE);
            $("#GSTRate").val(ItemDtl.GSTRate);
            $("#PurchaseCost").val(ItemDtl.PurchaseCost);
            $("#SellingPrice").val(ItemDtl.SellingPrice);
        }
    });


    //End Of Search Item Master


});