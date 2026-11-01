$(document).ready(function () {
    //alert('Its Coming from Gridview AJax');
    loadData();
    
    
});
// Url To get data from Api
//var GetDataItemById = API_URL + 'ItemMaster/GetItemMasterDataByID';
var url_BindManufacturer = API_URL + 'ItemMaster/BindManfacturer';
var url_BindColor = API_URL + 'ItemMaster/BindColor';
var url_BindUom = API_URL + 'ItemMaster/BindUom';
var url_BindCategory = API_URL + 'ItemMaster/BindCategory';
var GetAllItemMaster = API_URL + 'ItemMaster/GetAllItemMasterData';
var url_SaveItemMaster = API_URL + 'ItemMaster/SaveData';
var url_UpdateItemMaster = API_URL + 'ItemMaster/UpdateData';
//var url_UpdateItemMaster = API_URL + 'ItemMaster/UpdateData'; SearchItemMaster ItemCode


//var url_GetItemMasterByItemCode = API_URL + 'ItemMaster/UpdateDataGridView';

//Function to Get Item Master Details By ItemCode
function GetDataByItemCode(ID) {
    //alert('its coming after button click');

    $.ajax({
        //url: API_URL +'ItemMaster/GetItemMasterDataByID?ID='+ID,
        url: API_URL + 'ItemMaster/GetItemDataById?ID=' + ID ,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (ItemDtl) {
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



            $('#myModal').modal('show');
            $('#btnUpdateItem').show();
            $('#btnSaveItem').hide();
            //$('#txtItemCode');
            $('#txtItemCode').attr('readonly', 'true');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//End Of the function

function loadData() {
    $.ajax({
        type: "GET",
        url: GetAllItemMaster,
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });


    function OnSuccess(response) {
       
        var ItemMasterData = [];
        $.each(response, function (key, value) {
            console.log(value);
            //var ediBtn = "<a onclick='return  getDatabyItemCode(' + value.ItemCode + ')' class='btn btn-warning'>Edit</a>";
            //var editButton = "<input type= 'button' onclick='EditEmployee(" + value.ItemCode + ")' class='btn btn-warning' value ='Edit' id='btnEditData' />"
            var editButton = "<input type= 'button' onclick='GetDataByItemCode( " + value.ID + ")' class='btn btn-warning' value ='Edit' id='btnEditData' />"
            
            //var EB = < a href="#" onclick="return getbyID(+value.ItemCode+)" > Edit</a>;
            //var EB= <a onclick="return getbyID('+ value.ItemCode + ')">Edit</a>
            //var ediBtn = <a href="#" onclick=" return getCustbyID('+ value.CustomerID +')">Edit </a>

            // var removeBtn = "<a onclick='Remove(this)' class='btn btn-danger'>Remove</a>";
            var hdn = "<input type='hidden' id='hdnValue' value=" + value.ID + " >";
            var ActionLink = editButton + hdn;
            ItemMasterData.push([value.ID, value.ItemCode, value.ItemName, value.ManufacturerName, value.Material, value.CategoryName, value.SubCategoryName,
            value.ColourName, value.UnitName, value.HSNCODE, value.GSTRate, value.PurchaseCost, value.SellingPrice, ActionLink])
        })
        
        $("#tblItemMaster").DataTable(
            {
                
                "columnDefs": [{
                    "targets": [0], //Comma separated values[0,1,2,3] for multiple column hide
                    "visible": false,
                    "searchable": false
                }
                ],
                data: ItemMasterData,
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
                
                
            });
    }

   
}

$("#btnEditData").click(function () {
    alert('ok coming');
   


});

$("#btnAddItemDemo").click(function () {
    //alert('ok coming');
    $('#btnUpdateItem').hide();
    //$('#txtItemCode').val();
    $('#txtItemCode').attr('readonly',);
    //$('#txtItemCode').attr();


});

$(function () {
    $("#btnClose").bind("click", function () {
        $("#drpManufacturer")[0].selectedIndex = 0;
        $("#drpCategory")[0].selectedIndex = 0;
        $("#drpColor")[0].selectedIndex = 0;
        $("#drpUOM")[0].selectedIndex = 0;
        //$("#drpSubCategory")[0].selectedIndex = 0;
        //$('#drpSubCategory').val("");

    });
});  


//To clear Textbox
function clearTextBox() {
    $('#txtItemCode').val("");
    $('#txtItemName').val("");
    $('#drpManufacturer').val("");
    $('#txtItemMaterial').val("");
    $('#drpCategory').val("");
    $('#drpSubCategory').val("");
    $('#drpColor').val("");
    $('#drpUOM').val("");
    $('#txtItemHSN').val("");
    $('#txtGSTRate').val("");
    $('#txtItemPurchaseCost').val("");
    $('#txtItemSellingCost').val("");
    //On Add Button Click
    $('#btnSaveItem').show();

    $('#txtItemCode').css('border-color', 'lightgrey');
    $('#txtItemName').css('border-color', 'lightgrey');
    $('#drpManufacturer').css('border-color', 'lightgrey');
    $('#txtItemMaterial').css('border-color', 'lightgrey');
    $('#drpCategory').css('border-color', 'lightgrey');
    $('#drpSubCategory').css('border-color', 'lightgrey');
    $('#drpColor').css('border-color', 'lightgrey');
    $('#drpUOM').css('border-color', 'lightgrey');
    $('#txtItemHSN').css('border-color', 'lightgrey');
    $('#txtGSTRate').css('border-color', 'lightgrey');
    $('#txtItemPurchaseCost').css('border-color', 'lightgrey');
    $('#txtItemSellingCost').css('border-color', 'lightgrey');

}

//Valdidation using jquery  
function validate() {
    var isValid = true;
    //if ($('#txtItemCode').val().trim() == "") {
    //    $('#txtItemCode').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#txtItemCode').css('border-color', 'lightgrey');
    //}
    if ($('#txtItemName').val().trim() == "") {
        $('#txtItemName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtItemName').css('border-color', 'lightgrey');
    }

    if ($('#drpManufacturer').val() == '-1') {
        $('#drpManufacturer').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#drpManufacturer').css('border-color', 'lightgrey');
    }
    if ($('#txtItemMaterial').val().trim() == "") {
        $('#txtItemMaterial').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtItemMaterial').css('border-color', 'lightgrey');
    }

    if ($('#drpCategory').val().trim() == '-1') {
        $('#drpCategory').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#drpCategory').css('border-color', 'lightgrey');
    }
    //if ($('#drpSubCategory').val().trim() == "-1") {
    //    $('#drpSubCategory').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#drpSubCategory').css('border-color', 'lightgrey');
    //}
    if ($('#drpColor').val().trim() == "-1") {
        $('#drpColor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#drpColor').css('border-color', 'lightgrey');
    }
    if ($('#drpUOM').val().trim() == "-1") {
        $('#drpUOM').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#drpUOM').css('border-color', 'lightgrey');
    }
    if ($('#txtItemHSN').val().trim() == "") {
        $('#txtItemHSN').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtItemHSN').css('border-color', 'lightgrey');
    }
    if ($('#txtGSTRate').val().trim() == "") {
        $('#txtGSTRate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtGSTRate').css('border-color', 'lightgrey');
    }
    if ($('#txtItemPurchaseCost').val().trim() == "") {
        $('#txtItemPurchaseCost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtItemPurchaseCost').css('border-color', 'lightgrey');
    }
    if ($('#txtItemSellingCost').val().trim() == "") {
        $('#txtItemSellingCost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtItemSellingCost').css('border-color', 'lightgrey');
    }
    return isValid;
}

//Binding Manufacturer Dropdown
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
// End Of Manufacturer

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
function BindSubCategory(CategoryId) {
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
    $('#drpSubCategory').empty().append('<option selected="selected" value="0">-Select-</option>');
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

//Add Item Master Data To Database Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
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
        url: url_SaveItemMaster ,
        data: JSON.stringify(SaveData),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: OnSuccessSaveItemMaster,
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    function OnSuccessSaveItemMaster(response)
    {
        var ItemDtl = response;
        alert(ItemDtl);
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

        $('#btnSaveItem').hide();
        $('#btnUpdateItem').hide();


    }
}




//Update Item Master Function   
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
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
        url: url_UpdateItemMaster,
        data: JSON.stringify(UpdateData),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: OnSuccessUpdateItemMaster,
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    function OnSuccessUpdateItemMaster(response) {
        var ItemDtl = response;
        alert(ItemDtl);
        //$("#txtItemCode").val(ItemDtl.ItemCode);
        //$("#txtItemName").val(ItemDtl.ItemName);
        //$("#drpManufacturer").val(ItemDtl.ManufacturerId);
        //$("#txtItemMaterial").val(ItemDtl.Material);
        //$("#drpCategory").val(ItemDtl.ItemCategoryId);
        //$("#drpSubCategory").val(ItemDtl.ItemSubCategoryId);
        //$("#drpColor").val(ItemDtl.ColourId);
        //$("#drpUOM").val(ItemDtl.UnitId);
        //$("#txtItemHSN").val(ItemDtl.HSNCODE);
        //$("#txtGSTRate").val(ItemDtl.GSTRate);
        //$("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
        //$("#txtItemSellingCost").val(ItemDtl.SellingPrice);

        LoadData();
    }
}
