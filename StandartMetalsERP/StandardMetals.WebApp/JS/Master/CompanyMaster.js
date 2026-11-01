$(document).ready(function () {

    //alert('Its Working Yaaa');

    // Variables to declare URL
    var Url_CountryMaster = API_URL + 'CompanyMaster/BindCountry';
    var Url_CompanySearchMaster = API_URL + 'CompanyMaster/FillCompanyMaster';
    var url_UpdateItemMaster = API_URL + 'CompanyMaster/UpdateCompanyInfo';
     
    

    // Dropdown to bind Country

    var ddCountry = $("[id*=Country]");
    $.ajax({
        type: "GET",
        //  type: "POST",
        url: Url_CountryMaster,
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
            ddCountry.append($("<option>--Select--</option>").val(this['CountryId']).html(this['CountryName']));
        });

    }


    //function to bind state against country dropdown change

    function BindStateMaster(countryId) {
        //$('#drpCategory').change(function () {
        var ddStateMaster = $('#State').val();
        //alert(CategoryId);
        var obj = { countryId: countryId }
        $('#State').empty();

        $.ajax({
            //type: "GET",
            type: "POST",
            url: API_URL + 'CompanyMaster/BindState?countryId=' + countryId,
            /*url: API_URL +'ItemMaster/BindSubCategory'*/
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessBindCountryMaster,
            failure: function (response) {
                alert(response.d);
            }
        });

    }

    function OnSuccessBindCountryMaster(response) {
        //alert("data came");
        var StateCodeList = response;
        //alert(StateCodeList);
        //$('#drpSubCategory').empty().append('<option selected="selected" value="0">-select-</option>');
        $.each(StateCodeList, function () {
            ddStateMaster.append($("<option></option>").val(this['StateId']).html(this['StateName']));
        });


    }

    //to get value from drop down category

    //var CategoryId = $('#drpCategory').val();
    var ddStateMaster = $("[id*=State]");


    $('#Country').change(function () {
        BindStateMaster($('#Country').val());
        
    });




    //function to bind city against state dropdown change
    function BindCityMaster(stateId) {
        //$('#drpCategory').change(function () {
        //var ddCityMaster = $('#City').val();
        //alert(CategoryId);
        var obj = { stateId: stateId }
        $('#City').empty();

        $.ajax({
            //type: "GET",
            type: "POST",
            url: API_URL + 'CompanyMaster/BindCity?stateID=' + stateId,
            /*url: API_URL +'ItemMaster/BindSubCategory'*/
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessBindCityMaster,
            failure: function (response) {
                alert(response.d);
            }
        });

    }

    function OnSuccessBindCityMaster(response) {
        //alert("data came");
        var StateCodeList = response;
        //alert(StateCodeList);
        //$('#drpSubCategory').empty().append('<option selected="selected" value="0">-select-</option>');
        $.each(StateCodeList, function () {
            ddCityMaster.append($("<option></option>").val(this['CityId']).html(this['CityName']));
        });


    }

    //to get value from drop down category

    //var CategoryId = $('#drpCategory').val();
    var ddCityMaster = $("[id*=City]");


    $('#State').change(function () {
        BindCityMaster($('#State').val());

    });


    //Bindig Form With Company Information

    $.ajax({
        type: "GET",
        url: Url_CompanySearchMaster,
        //url: url_SearchItemMaster + "?ItemCode=" + ItemCode,

        headers: {
            "Authorization": "Basic" + Token,
            "Content-Type": "application/json"
        },
        // data: "{'ItemCode':'" + ItemCode + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessSearchCountryMaster,
        failure: function (response) {
            alert(response);
        }
    });
    function OnSuccessSearchCountryMaster(response) {
        var ItemDtl = response;
        alert(ItemDtl);
       //$("#txtItemCode").val(ItemDtl.ItemCode);
        $("#CmpName").val(ItemDtl.CmpName);
        $("#Address1").val(ItemDtl.Address1);
        $("#Address2").val(ItemDtl.Address2);
        $("#Country").val(ItemDtl.Country);
        $("#State").val(ItemDtl.State);
        $("#City").val(ItemDtl.City);
        $("#PinCode").val(ItemDtl.PinCode);
        //BindSubCategory(ItemDtl.ItemCategoryId);
        $("#EmailID").val(ItemDtl.EmailID);
        $("#Telephone").val(ItemDtl.Telephone);
        $("#Mobile").val(ItemDtl.Mobile);
        $("#ContactPerson").val(ItemDtl.ContactPerson);
        $("#Website").val(ItemDtl.Website);
        $("#GSTIN").val(ItemDtl.GSTIN);
    }

    //code to update Company Information

    $("#btnUpdate").click(function () {
        alert('update button is clicked');
        var UpdateData = {
            CmpName: $("[id*=CmpName]").val(),
            Address1: $("[id*=Address1]").val(),
            Address2: $("#Address2").val(),
            Country: $("#Country").val(),
            State: $("#State").val(),
            City: $("#City").val(),
            PinCode: $("#PinCode").val(),
            EmailID: $("#EmailID").val(),
            Telephone: $("#Telephone").val(),
            Mobile: $("#Mobile").val(),
            ContactPerson: $("#ContactPerson").val(),
            Website: $("#Website").val(),
            GSTIN: $("#GSTIN").val()

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
            $("#CmpName").val(ItemDtl.CmpName);
            $("#Address1").val(ItemDtl.Address1);
            $("#Address2").val(ItemDtl.Address2);
            $("#Country").val(ItemDtl.Country);
            $("#State").val(ItemDtl.State);
            $("#City").val(ItemDtl.City);
            $("#PinCode").val(ItemDtl.PinCode);
            $("#EmailID").val(ItemDtl.EmailID);
            $("#Telephone").val(ItemDtl.Telephone);
            $("#Mobile").val(ItemDtl.Mobile);
            $("#ContactPerson").val(ItemDtl.ContactPerson);
            $("#Website").val(ItemDtl.Website);
            $("#GSTIN").val(ItemDtl.GSTIN);
        }
    });





    //End Of update company information


});