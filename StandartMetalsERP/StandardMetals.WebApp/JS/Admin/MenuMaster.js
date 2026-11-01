$(document).ready(function () {
    alert('inside from jquery form');

    // Variables to declare URL
    var Url_BindMasterMenu = API_URL + 'Admin/BindMasterMenu';
    var Url_SaveMasterMenu = API_URL + 'Admin/SaveMasterMenu';
    
    //var url_UpdateItemMaster = API_URL + 'CompanyMaster/UpdateCompanyInfo';

    var ddMasterMenu = $("[id*=MenuId]");
    $.ajax({
        type: "GET",
        //  type: "POST",
        url: Url_BindMasterMenu,
        headers: {
            "Authorization": "Basic " + Token,
            "Content-Type": "application/json"
        },
        //data: '{name: "aalim"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBindMasterMenu,
        failure: function (response) {
            alert(response.d);
        }
    });

    function OnSuccessBindMasterMenu(response) {
        // alert("data came");
        var StateCodeList = response;
        //  alert(StateCodeList);
        $.each(StateCodeList, function () {
            ddMasterMenu.append($("<option>--Select--</option>").val(this['MasterMenuId']).html(this['MenuName']));
        });

    }

    //code to save Master Menu in database
    $("#btnSaveMenu").click(function () {
        var BName = BranchName;
        var SaveData = {
            MenuName: $("[id*=MenuName]").val(),
            IsActive: $("[id*=IsActive]").val(),
            BranchName: BName
        };

        $.ajax({
            type: "POST",
            url: Url_SaveMasterMenu,
            headers: {
                "Authorization": "Basic " + Token,
                "Content-Type": "application/json"
            },
            data: JSON.stringify(SaveData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessSaveMasterMenu,
            failure: function (response) {
                alert(response.d);
            }
        });
        function OnSuccessSaveMasterMenu(response) {
            var ItemDtl = response;
            alert(ItemDtl);
            $("#MenuName").val(ItemDtl.MenuName);
            $("#IsActive").val(ItemDtl.IsActive);

        }

    });

    


});