$(function () {
    $("#OrganizationDD").change(function () {
        $("#OrganizationId").val($(this));
    });
});
$(function () {
    $("#CourseDD").change(function () {
        $("#CourseId").val($(this));
    });
});


$(document).ready(function() {
   
    var d = new Date();
    var ms = d.getMilliseconds();
    var yy = d.getFullYear().toString().substr(-2);
    var m = d.getMonth();
    var mm = "";
    if (m < 10) {
         mm = "0" + m;
    } else {
         mm = m;
    }
    $.ajax({
        data: JSON.stringify(),
        contentType: "application/Json; charset=utf-8",
        type: "POST",
        url: "../../Student/GetLastRegNo",
        dataType: 'json',
        success: function (result) {
            result = result + 1;
            var val="";
            if (result < 10) {
                 val = "00" + result;
            }
            else if (result < 100) {
                 val = "0" + result;
            } else {
                 val = result;
            }
            var regNo = "PRCPT" + "-" + ms + "-" + yy + "-" + mm + "-" + val;

            $("#regNoTextBox").val(regNo);
        }


    });
});