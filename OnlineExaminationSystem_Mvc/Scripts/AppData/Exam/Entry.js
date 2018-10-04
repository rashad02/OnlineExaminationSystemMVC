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


$(function () {
    $("#CourseDD").on("change", function () {
        $("#CourseId").val($(this));
    });
});
$(function () {
    $("#ExamTypeDD").change( function () {
        var Type = $("#ExamTypeDD option:selected").text();
        $("#ExamType").val(Type);
    });
});