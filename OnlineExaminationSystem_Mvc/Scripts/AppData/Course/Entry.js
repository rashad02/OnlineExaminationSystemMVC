
$(document).ready(function () {
    $('.nav-tabs > li > a').click(function (event) {
        event.preventDefault();//stop browser to take action for clicked anchor

        //get displaying tab content jQuery selector
        var active_tab_selector = $('.nav-tabs > li.active > a').attr('href');

        //find actived navigation and remove 'active' css
        var actived_nav = $('.nav-tabs > li.active');
        actived_nav.removeClass('active');

        //add 'active' css into clicked navigation
        $(this).parents('li').addClass('active');

        //hide displaying tab content
        $(active_tab_selector).removeClass('active');
        $(active_tab_selector).addClass('hide');

        //show target tab content
        var target_tab_selector = $(this).attr('href');
        $(target_tab_selector).removeClass('hide');
        $(target_tab_selector).addClass('active');
    });


  


});


//$('#SaveButton').click(function() {

//     var courseVm = {
//         Organizations: [{ Id: $("#Organize option:selected").val() }],
//         Coursename: $("#CourseName").val(),
//         CourseCode: $("#CourseCode").val(),
//         Duration: $("#Duration").val(),
//         Credit: $("#Credit").val(),
//         Outline: $("#Outline").val(),
//         TagsId: [{ Tags: $("#Tags option:selected").val() }]
//    };


//    $.ajax({

//        //Convert Parameter From Js Object To JSon Object
//        data: (courseVm),
//        //Type Get/ Post
//        type: "POST",

//        //Url / Link
//        url: "../../Course/AddCourse",
       
//        //Convert Type To Json Format 
//        // data1 :JSON.stringify(data),
//       contentType: "application/Json; charset=utf-8",
//       dataType: 'json',

////Call back Function With Response Data
//        success: function() {
//            alert("View Returns");
//        }


//    });
//});

////$("#UpdateButton").click(function () {


////    var course = {

////        OrganizationName: $("#myId").val(),
////        Coursename: $("#CourseNa").val(),
////        CourseCode: $("#CourseCo").val(),
////        Duration: $("#Duratn").val(),
////        Credit: $("#Credt").val(),
////        Outline: $("#Outne").val(),
////        TagsList: $("#TagList").val()
////    };


////    $.ajax({

////        //Convert Parameter From Js Object To JSon Object

////        data: course,
////        //Type Get/ Post
////        type: "POST",

////        //Url / Link
////        url: "../../Course/Entry",
////        dataType: 'json',
////        //Convert Type To Json Format 
////        // data1 :JSON.stringify(data),
////        //contentType: "application/Json; charset=utf-8",



////        //Call back Function With Response Data
////        success: function () {
////            alert("View Returns");
////        }


////    });
////})


////$("#AddTrainerButton").click(function() {







////});


$(function(){
$("#Id").on("change", function() {
   $("#OrganizationId").val($(this));
 });
});

$(function () {
    $("#Id").on("change", function () {
        $("#TagsId").val($(this));
    });
});

$(function () {
    $("#Id").on("change", function () {
        $("#TrainerId").val($(this));
    });
});

$('#AddTrainerButton').click(function() {
    var trainerName = $('#Trainer option:selected').text();
   
    var index = $('#tranierDetailsBody').children('tr').length;

    var indexTd = "<td> "+(index+1)+"</td>";
   
    var nameTd = "<td>"+trainerName+"</td>";
    var radio = '<td> <input type="radio" id="leadTrainerRadio' + (index+1) + '" /></td>';
     var action='<td><a href="#">Edit</a> | <a href="#">Delete</a></td>';
     var newRow = "<tr>'" + indexTd +nameTd+ radio + action + "'</tr>";
      $('#tranierDetailsBody').append(newRow);

});


$('#SaveTrainerButton').click(function() {
    var TrainerList = [];
    var trainerType = 0;

    $("table tr:not(:first)").each(function () {
        var index = (this.rowIndex);
        if (index == 0) {
            return;
        }
        var tdlist = $(this).find("td");
        var Item = {
            Name:$(tdlist[1]).text(),       
        };
        TrainerList.push(Item);
        trainerType= GetTrainerType(index);
    });

    var courseEntryVm = { Trainers: TrainerList, TrainerType: trainerType };

    $.ajax({

            //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify({ 'courseEntryVm': courseEntryVm }),
        contentType: "application/Json; charset=utf-8",
                //Type Get/ Post
                type: "POST",

                //Url / Link
                url: "../../Course/TrainerAdded",
               dataType: 'json',
                //Convert Type To Json Format 
                //data: JSON.stringify(itemlist),
                



                //Call back Function With Response Data
                success: function () {
                    alert("View Returns");
                }


            });



});

function GetTrainerType(index) {
    
    if (document.getElementById("leadTrainerRadio" + index + "").checked) {
        return 1;
    } else {
        return 0;
    }
}


$("#SaveExamButton").click(function () {

    var courseId = $("#CourseTB option:selected").text();
    var examType = $("#ExamTypeDD").val();
    var examCode = $("#ExamCode").val();
    var topic = $("#Topic").val();
    var fullMarks = $("#FullMarks").val();
    var hour = $("#Hour").val();
    var minute = $("#Minute").val();

    var examEntryVm= {
        courseId: courseId,
        examType: examType,
        examCode: examCode,
        topic: topic,
        fullMarks: fullMarks,
        hour: hour,
        minute: minute
    }

    $.ajax({

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify({ examEntryVm: examEntryVm }),
        contentType: "application/Json; charset=utf-8",
        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Course/CourseExamAdd",
        dataType: 'json',
        //Convert Type To Json Format 
        //data: JSON.stringify(itemlist),




        //Call back Function With Response Data
        success: function (result) {
           
            $.each(result, function (k, v) {
                
                var typeTd = "<td> " + v.ExamType + "</td>";
                var topicTd = "<td> " + v.Topic + "</td>";
                var codeTd = "<td> " + v.ExamCode + "</td>";
                var durationTd = "";
                if (v.Duration.Hours < 10) {
                    durationTd = "<td> 0" + v.Duration.Hours + ":" + v.Duration.Minutes + "</td>";
                } else {
                   durationTd = "<td> " + v.Duration.Hours + ":" + v.Duration.Minutes + "</td>";
                }

                
             
                
                var fullMarksTd = "<td> " + v.FullMarks + "</td>";
                var actionTd = '<td> <a href="#">View</a> | <a href="#">Edit</a> | <a href="#">Delete</a></td>';
                var tr = "<tr> " + typeTd + topicTd + codeTd + durationTd + fullMarksTd + actionTd + "</tr>";
                $("#CourseExamTable").append(tr);
            });

           
        }


    });





});