$(document).ready(function () {
    //alert('inside from jquery form');
    LoadData();
    // Variables to declare URL
    var Url_BindRoleMasterMenu = API_URL + 'Admin/BindRoleMasterItem';


    $("#btnSave").click(function () {
        alert('its working');
         

            // Let's put this in the object like you want and convert to JSON (Note: jQuery will also do  this for you on the Ajax request)
        alert(JSON.stringify(tableToJSON($("#tblRoleMaster"))));
       

    });

    tableToJSON = function (tblObj) {
        alert('fn clled');
        var data = [];
        var $headers = $(tblObj).find("th");
        var $rows = $(tblObj).find("tbody tr").each(function (index) {
            $cells = $(this).find("td");
            data[index] = {};
            $cells.each(function (cellIndex) {
                data[index][$($headers[cellIndex]).html()] = $(this).html();
            });
        });
        return data;
    }

    //var Url_SaveSubMasterMenu = API_URL + 'Admin/SaveSubMenuMaster';

    var ddRoleMasterMenu = $("[id*=RoleId]");
    $.ajax({
        type: "GET",
        //  type: "POST",
        url: Url_BindRoleMasterMenu,
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
            ddRoleMasterMenu.append($("<option>--Select--</option>").val(this['RoleId']).html(this['RoleName']));
        });

    }


    // Function to get Role Master Details

   
});
//Url to get data
var Url_GetMenuDetails = API_URL + 'Admin/GetMenuDetail';


function LoadData() {


    $.ajax({
        type: "GET",
        url: Url_GetMenuDetails,
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

        var GetMenuDetails = [];
        $.each(response, function (key, value) {
            console.log(value);
            //var ediBtn = "<a onclick='return  getDatabyItemCode(' + value.ItemCode + ')' class='btn btn-warning'>Edit</a>";
            //var editButton = "<input type= 'button' onclick='EditEmployee(" + value.ItemCode + ")' class='btn btn-warning' value ='Edit' id='btnEditData' />"
            //var editButton = "<input type= 'button' onclick='GetDataByItemCode( " + value.ID + ")' class='btn btn-warning' value ='Edit' id='btnEditData' />"
            //var EB= <a onclick="return getbyID('+ value.ItemCode + ')">Edit</a>
            // var removeBtn = "<a onclick='Remove(this)' class='btn btn-danger'>Remove</a>";
            //var hdn = "<input type='hidden' id='hdnValue' value=" + value.ID + " >";
            var check = "<input type ='checkbox' id='chkCheck' >"
            var addCheck = "<input type ='checkbox' id='chkAdd' >"
            var UpdateCheck = "<input type ='checkbox' id='chkUpdate' >"
            var deleteCheck = "<input type ='checkbox' id='chkDelete' >"
            var searchCheck = "<input type ='checkbox' id='chkSearch' >"

            //var ActionLink = editButton + hdn;
            GetMenuDetails.push([check, value.SubMenuName, value.MenuName, addCheck, UpdateCheck,
                deleteCheck, searchCheck])
        })

        $("#tblRoleMaster").DataTable(
            {

                data: GetMenuDetails,
                bLengthChange: true,
                //lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                //bFilter: true,
                //bSort: true,
                //bPaginate: true


            });
    }
}

