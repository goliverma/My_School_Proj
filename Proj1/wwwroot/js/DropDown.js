$(document).ready(function () {
    BindCountry();
});
function enter() {
    let dddd = $('#cid').val();
    if (dddd == 0) {
        $("#sid").append($('<option></option>').html("---Select---").val(0));
        $("#cityid").append($('<option></option>').html("---Select---").val(0));
    }
}
function BindCountry() {

    $.ajax({
        url: '/Student/GetCountry',
        type: 'get',
        data: {},
        async: false,
        success: function (Data) {
            
            $("#cid").append($('<option></option>').html("---Select---").val(0));
            for (let i = 0; i < Data.length; i++) {
                $("#cid").append($('<option></option>').html(Data[i].cName).val(Data[i].cid));
            }
            enter();
        },
        error: function () {
            alert('Data Not Found');
        }
    });
};
function BindState() {
    $.ajax({
        url: '/Student/GetState',
        type: 'get',
        data: { sid: $("#cid").val() },
        async: false,
        success: function (Data) {
            $("#sid").empty();
            $("#sid").append($('<option></option>').html("---Select---").val(0));
            debugger;
            for (let i = 0; i < Data.length; i++) {
                $("#sid").append($('<option></option>').html(Data[i].sName).val(Data[i].sid));
            }
        },
        error: function (Data) {
            alert(Data);
        }
    });
};
function BindCity() {
    $.ajax({
        url: '/Student/GetCity',
        type: 'get',
        data: { Stateid: $("#sid").val() },
        async: false,
        success: function (Data) {
            debugger;
            $("#cityid").empty();
            $("#cityid").append($('<option></option>').html("---Select---").val(0));
            for (let i = 0; i < Data.length; i++) {
                $("#cityid").append($('<option></option>').html(Data[i].cityName).val(Data[i].cityId));
            }
        },
        error: function (Data) {
            alert(Data);
        }
    });
};