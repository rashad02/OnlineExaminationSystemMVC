//$(document).ready(function () {
//  $('#dtBasicExample').DataTable();
//  $('.dataTables_length').addClass('bs-select');
//});


$("#SeachButton").click(function() {
  //  OrganizationId: $("#Organization option:selected").val(),
    $("#SearchTableContent").empty();
    var course = {
                
                 Coursename: $("#CourseName").val(),
                 CourseCode: $("#CourseCode").val(),
                 Duration: $("#Duration").val(),
                 Credit: $("#Credit").val(),
                 Outline: $("#Outline").val(),
                 
            };

    $.ajax({

        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Course/SearchByCourseProperty",

        //Convert Type To Json Format 
        contentType: "application/json; charset=utf-8",

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify({ course: course }),
        dataType: 'json',
        //Call back Function With Response Data
        success: function(result) {
            var sl = 1;
            $.each(result, function (k,v) {
    
              
              //  alert(v.TrainerData[Name]);

                
                var slTd = "<td>" + sl + " </td> ";
                var nameTd = "<td>" + v.CourseName + " </td> ";
                var durationTd = "<td>" + v.Duration + " </td> ";
                var trainerTdValue = "";
                for (var i = 0; i < v.TrainerData.length; i++) {
                    trainerTdValue = trainerTdValue + v.TrainerData[i].Name;
                }
                var trainerTd = "<td>" + trainerTdValue + " </td> ";
                var actionTd = '<td><a href="#">View</a> | <a href="#">Edit</a> | <a href="#">Delete</a> </td> ';

                $("#SearchTableContent").append("<tr>" + slTd +nameTd+durationTd+trainerTd+actionTd+ " </tr>");
                sl++;
            });

        }


    });

});



$("#Organization").change(function () {
   
    var organizationId = $("#Organization option:selected").val();

   
    $.ajax({

        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Course/SearchByOrganizationId",

        //Convert Type To Json Format 
        contentType: "application/json; charset=utf-8",

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify({ Id: organizationId }),
        dataType: 'json',
        //Call back Function With Response Data
        success: function (result) {
            $("#SearchTableContent").empty();
            var sl = 1;
            $.each(result, function (k, v) {


                //  alert(v.TrainerData[Name]);


                var slTd = "<td>" + sl + " </td> ";
                var nameTd = "<td>" + v.CourseName + " </td> ";
                var durationTd = "<td>" + v.Duration + " </td> ";
                var trainerTdValue = "";
                for (var i = 0; i < v.TrainerData.length; i++) {
                    trainerTdValue = trainerTdValue + v.TrainerData[i].Name;
                }
                var trainerTd = "<td>" + trainerTdValue + " </td> ";
                var actionTd = '<td><a href="#">View</a> | <a href="#">Edit</a> | <a href="#">Delete</a> </td> ';

                $("#SearchTableContent").append("<tr>" + slTd + nameTd + durationTd + trainerTd + actionTd + " </tr>");
                sl++;
            });

        }


    });

});
