

$(document).ready(function() {
   // $("#CourseDD").disabled = true;
    document.getElementById("CourseDD").disabled = true;
    document.getElementById("StudentDD").disabled = true;
    document.getElementById("ExamTypeDD").disabled = true;
    //$("#StudentDD").disabled = true;
    //$("#ExamTypeDD").disabled = true;
});


$('#OrganizationDD').change(function () {
    var Type = $("#OrganizationDD option:selected").text();
    $("#OrganizationName").val(Type);
    document.getElementById("CourseDD").disabled = false;
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
                $.each(rData, function (k, v) {
                    $("#CourseDD").append("<option value='" + v.Id + "'>" + v.CourseName + "</option>");
                });

            }
        }


    });

});

$('#CourseDD').change(function () {
    document.getElementById("OrganizationDD").disabled = true;
    document.getElementById("StudentDD").disabled = false;
    document.getElementById("ExamTypeDD").disabled = false;

    var courseId = $(this).val();

    var params = { id: courseId }
    $.ajax({

        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Exam/GetStudentExamByCourseId",

        //Convert Type To Json Format 
        contentType: "application/Json; charset=utf-8",

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify(params),
        dataType: 'json',
        //Call back Function With Response Data
        success: function (rData) {
            $("#ExamTypeDD").empty();
            $("#StudentDD").empty();

           
            if (rData != undefined && rData != "") {
                $.each(rData, function (k, v) {
                    $("#ExamTypeDD").append("<option value='" + v.Id + "'>" + v.ExamCode + "</option>");
                    $("#StudentDD").empty();
                    $.each(v.StudentData, function (k, v) {
                        $("#StudentDD").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                    });
                });
              
            }
        }


    });

});