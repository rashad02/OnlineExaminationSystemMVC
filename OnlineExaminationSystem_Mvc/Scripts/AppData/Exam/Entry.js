$(document).ready(function() {
    $("#CourseDD").change(function() {
        $("#CourseId").val($(this));
    });
    $("#OrganizationDD").change(function() {
        $("#OrganizationId").val($(this));
    });
    $("#ExamTypeDD").change(function() {
        var Type = $("#ExamTypeDD option:selected").text();
        $("#ExamType").value = Type;
    });
});





$('#OrganizationDD').change(function () {

    var organizationId = $(this).val();
    
    var params = { id: organizationId }
        $.ajax({

            //Type Get/ Post
            type: "POST",

            //Url / Link
            url: "../../Exam/GetCourseByOrganizationId",

            //Convert Type To Json Format 
            contentType: "application/Json; charset=utf-8",

            //Convert Parameter From Js Object To JSon Object
            data: JSON.stringify(params),
            dataType: 'json',
            //Call back Function With Response Data
            success: function (rData) {
                $("#CourseDD").empty();
                $("#CourseDD").append("<option value=''>---SELECT---</option>");
                if (rData != undefined && rData != "") {
                    $.each(rData, function(k, v) {
                        $("#CourseDD").append("<option value='" + v.Id + "'>" + v.CourseName + "</option>");
                    });
                } 
            }
        });

  


});


//$(function () {
//    $("#CourseDD").change(function () {
//        $("#CourseId").val($(this));
//    });
//});
//$(function () {
//    $("#OrganizationDD").change(function () {
//        $("#OrganizationId").val($(this));
//    });
//});
$(function () {
    $("#ExamTypeDD").on("change", function () {
       // var Type = $("#ExamTypeDD option:selected").val();
        $("#ExamTypeId").val($("#ExamTypeDD option:selected").val());
    });
});