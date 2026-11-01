$(document).ready(function () {
    alert('Yes its coming from Jquery');
    var ddCategoryMaster = $("[id*=ManufacturerId]");
    var BindCategoryMaster = API_URL + 'ItemMaster/BindCategory';

    $.ajax({
        type: "GET",
        //  type: "POST",
        url: BindCategoryMaster,
        headers: {
            "Authorization": "Basic " + Token,
            "Content-Type": "application/json"
        },
        //data: '{name: "aalim"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessCategoryMaster,
        failure: function (response) {
            alert(response.d);
        }
    });

    function OnSuccessCategoryMaster(response) {
        // alert("data came");
        var StateCodeList = response;
        //  alert(StateCodeList);
        $.each(StateCodeList, function () {
            ddCategoryMaster.append($("<option></option>").val(this['CategoryId']).html(this['CategoryName']));
        });

    }

});
