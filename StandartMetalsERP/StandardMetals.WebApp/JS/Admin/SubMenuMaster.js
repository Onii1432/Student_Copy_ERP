$(document).ready(function () {
    alert('inside from jquery form');

    // Variables to declare URL
    var Url_BindMasterMenu = API_URL + 'Admin/BindMasterMenu';
    var Url_SaveSubMasterMenu = API_URL + 'Admin/SaveSubMenuMaster';

    var ddMasterMenu = $("[id*=MasterMenuId]");
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

    //code to save Sub Master Menu in database
    $("#btnSave").click(function () {
        alert('../' + $("[id*=SubMenuLink]").val() + '/' + $("[id*=Action]").val());
        var BName = BranchName;
        var SaveData = {
            MasterMenuId: $("[id*=MasterMenuId]").val(),
            SubMenuName: $("[id*=SubMenuName]").val(),
            SubMenuLink: '../' + $("[id*=SubMenuLink]").val() + '/' + $("[id*=Action]").val(),
            IsActive:  $("[id*=IsActive]").val(),
            BranchName : BName
        };

        $.ajax({
            type: "POST",
            url: Url_SaveSubMasterMenu,
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
            $("#MasterMenuId").val(ItemDtl.MasterMenuId);
            $("#SubMenuName").val(ItemDtl.SubMenuName);
            $("#SubMenuLink").val(ItemDtl.SubMenuLink);
            $("#IsActive").val(ItemDtl.IsActive);
            
        }

    });


    


});