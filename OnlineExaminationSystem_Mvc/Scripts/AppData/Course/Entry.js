
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

  
    $("#OrganizationId").val($("#OrganizationDD option:selected").val());
    $("#CourseId").val($("#CourseDD option:selected").val());
   
  



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
    $("#OrganizationDD").on("change", function () {
   $("#OrganizationId").val($(this));
 });
});

$(function () {
    $("#CourseDD").on("change", function () {
        $("#CourseId").val($(this));
    });
});


$(document).on("change", "#ExamTypeDD", function () {
    $("#ExamType").val($(this).find("option:selected").text());
});


$(function(){
    $("#ExamTypeDD").on("change", function () {
        $("#ExamTypeId").val($("ExamTypeDD option:selected").text());
 });
});

   

$('#AddTrainerButton').click(function() {
    var trainerName = $('#Trainer option:selected').text();
    var trainerId = $('#Trainer option:selected').val();
    var index = $('#tranierDetailsBody').children('tr').length;

    var indexTd = "<td> "+(index+1)+"</td>";
   
    var nameTd = "<td id=" + trainerId + ">" + trainerName + "</td>";
    var radio = '<td> <input type="radio" id="leadTrainerRadio' + (index+1) + '" /></td>';
    var action = '<td><a href="#" id="editLink" >Edit</a> | <a href="#" id="deleteLink">Delete</a></td>';
     var newRow = "<tr>'" + indexTd +nameTd+ radio + action + "'</tr>";
      $('#tranierDetailsBody').append(newRow);

});

//$(document).on('click', '#editLink', function () {


//    $('#OptionModal').modal('show');

////    var row = $(this).closest("tr").index();
////    var trainerId = document.getElementById("tranierDetailsBody").rows[row].cells[1].id;
////   // var trainerId = $("#Trainer option:selected").val();
////    $.ajax({

////        //Convert Parameter From Js Object To JSon Object
       
////        //Type Get/ Post
////        type: "POST",

////        //Url / Link
////        url: "../../Course/UpdateCourse",
////        data: JSON.stringify({ Id: trainerId }),
////        contentType: "application/Json; charset=utf-8",
      
////        //Convert Type To Json Format 
       


//////Call back Function With Response Data
////        success: function(result) {
////            $.redirect(window.location.href = "http://localhost:1093/Course/Update/" + result );
////        }
////    });
//});

$(document).on('click', '#deleteLink', function () {
    if (confirm("Do you want to Delete the row?")) {
        // your deletion code
        $(this).closest("tr").remove();
    }
    return false;
    
});




$(document).on('click', '#editLink', function() {
    var row = $(this).closest("tr").index();
    $("#rowIndexTrainer").val(row);
    var trainerId = document.getElementById("tranierDetailsBody").rows[row].cells[1].id;
    // var trainerId = $("#Trainer option:selected").val();
    $.ajax({

        //Convert Parameter From Js Object To JSon Object

        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Course/Update",
        data: JSON.stringify({ id: trainerId }),
        contentType: "application/Json; charset=utf-8",
      
        //Convert Type To Json Format 


//Call back Function With Response Data
        success: function(result) {
            $('#modalContent').html(result);
            $('#OptionModal').modal('show');
        }

    });

});



function onChangeSuccess(data) {
    $('#OptionModal').modal('hide');
    var row = document.getElementById("rowIndexTrainer").value;
    
    document.getElementById("tranierDetailsBody").rows[row].cells[1].innerText = data;
    $.ajax({
        type: "POST",
        url: "../../Course/GetTrainer",
        contentType: "application/JSON; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#Trainer").empty();
                $("#Trainer").append("<option value=''>--Select--</option>");

                $.each(rData, function (k, v) {
                    var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                    $("#Trainer").append(option);
                });

            } else {
                $("#Trainer").empty();
                $("#Trainer").append("<option value=''>--Select--</option>");

            }
        }

    });



    //document.getElementById("tranierDetailsBody").rows[row].remove();


//document.getElementById("tranierDetailsBody").rows[row].remove();


};

function onSaveSuccess(data) {
   
   
    $.ajax({
        type: "GET",
        url: "../../Course/CourseExamAdd",
        contentType: "application/Json; charset=utf-8",
        success: function(result) {
            $("#PartialViewExam").html(result);
            if (typeof data == "object") {
                                // Response is javascript object
                                //if (row != "") {
                                //    $("#SaveExamButton").val('Save');
                                //    document.getElementById("CourseExamTable").rows[row].remove();
                                //}
                var examType = "";
                                $.each(data, function (k, v) {
                                    var exmasid = '<td hidden="hidden">  ' + v.Id + '</td>';
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
                                    var actionTd = '<td> <a href="#" id="editExam">Edit</a> | <a href="#" id="deleteExam">Delete</a></td>';
                                    var tr = "<tr> " + exmasid + typeTd + topicTd + codeTd + durationTd + fullMarksTd + actionTd + "</tr>";
                                    $("#CourseExamTable").append(tr);
                                    examType = v.ExamType;
                                });
                                $("#rowIndex").val("");
                                $("#examId").val("");
                                $("#Topic").empty();
                                $("#FullMarks").empty();
                                $("#Hour").empty();
                                $("#Minute").empty();
                                $("#ExamCode").empty();
                                $("#ExamTypeDD").val(examType).trigger("chosen:updated");

                                $("#HiddenField").empty();

                            }
        }
    });
}



$(function () {
    // Delegating to `document` just in case.
    $('#OptionModal').on('hidden.bs.modal', function(e) {
        $('#OptionModal modal-body').load('@Url.Action("Update","Course")');
    });
    //$(document).on("hidden.bs.modal", "#OptionModal", function () {
    //    $('#OptionModal modal-body').load('@Url.Action("Update","Course")'); // Just clear the contents.
    //    //  $(this).find("#OptionsModal").remove(); // Remove from DOM.
    //});
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


//$("#SaveExamButton").click(function () {
//    var row = $("#rowIndex").val();
//    var id = $("#examId").val(); 
//    var courseId = $("#CourseDD option:selected").val();
//    var organizationId = $("#OrganizationDD option:selected").val();

//    var examType = $("#ExamTypeDD option:selected").text();
//    var examCode = $("#ExamCode").val();
//    var topic = $("#Topic").val();
//    var fullMarks = $("#FullMarks").val();
//    var hour = $("#Hour").val();
//    var minute = $("#Minute").val();
//    var examEntryVm = {};
//    if (id == "") {
//        examEntryVm = {
//            CourseId: courseId,
//            OrganizationId: organizationId,
//            examType: examType,
//            examCode: examCode,
//            topic: topic,
//            fullMarks: fullMarks,
//            hour: hour,
//            minute: minute
//        }
//    } else {
//         examEntryVm = {
//            Id: id,
//            CourseId: courseId,
//            OrganizationId: organizationId,
//            examType: examType,
//            examCode: examCode,
//            topic: topic,
//            fullMarks: fullMarks,
//            hour: hour,
//            minute: minute
//        }
//    }

//    $.ajax({

//        //Convert Parameter From Js Object To JSon Object
//        data: JSON.stringify({ examEntryVm: examEntryVm }),
//        contentType: "application/Json; charset=utf-8",
//        //Type Get/ Post
//        type: "POST",

//        //Url / Link
//        url: "../../Course/ExamAssign",
        
//        //Convert Type To Json Format 
//        //data: JSON.stringify(itemlist),




//        //Call back Function With Response Data
//        success: function (result) {
//            if (typeof result == "object") {
//                // Response is javascript object
//                if (row != "") {
//                    $("#SaveExamButton").val('Save');
//                    document.getElementById("CourseExamTable").rows[row].remove();
//                }

//                $.each(result, function (k, v) {
//                    var exmasid = '<td hidden="hidden">  ' + v.Id + '</td>';
//                    var typeTd = "<td> " + v.ExamType + "</td>";
//                    var topicTd = "<td> " + v.Topic + "</td>";
//                    var codeTd = "<td> " + v.ExamCode + "</td>";
//                    var durationTd = "";
//                    if (v.Duration.Hours < 10) {
//                        durationTd = "<td> 0" + v.Duration.Hours + ":" + v.Duration.Minutes + "</td>";
//                    } else {
//                        durationTd = "<td> " + v.Duration.Hours + ":" + v.Duration.Minutes + "</td>";
//                    }




//                    var fullMarksTd = "<td> " + v.FullMarks + "</td>";
//                    var actionTd = '<td> <a href="#" id="editExam">Edit</a> | <a href="#" id="deleteExam">Delete</a></td>';
//                    var tr = "<tr> " + exmasid + typeTd + topicTd + codeTd + durationTd + fullMarksTd + actionTd + "</tr>";
//                    $("#CourseExamTable").append(tr);
//                });
//                $("#rowIndex").val("");
//                $("#examId").val("");
//                $("#Topic").empty();
//                $("#FullMarks").empty();
//                $("#Hour").empty();
//                $("#Minute").empty();
//                $("#ExamCode").empty();
//                $("#ExamTypeDD").val(examType).trigger("chosen:updated");



//            }
//            else {
             
               
//            }


//        }


//    });





//});



$("#UpdateExamButton").click(function () {

    var row = $(this).closest("tr").index();
    $("#CourseExamTable").remove(row);
    var courseId = $("#CourseTB option:selected").text();
    var examType = $("#ExamTypeDD option:selected").text();
    var examCode = $("#ExamCode").val();
    var topic = $("#Topic").val();
    var fullMarks = $("#FullMarks").val();
    var hour = $("#Hour").val();
    var minute = $("#Minute").val();

    var examEntryVm = {
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
        url: "../../Course/CourseExamUpdate",
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
                var actionTd = '<td> <a href="#" id="editExam">Edit</a> | <a href="#" id="deleteExam">Delete</a></td>';
                var tr = "<tr> " + typeTd + topicTd + codeTd + durationTd + fullMarksTd + actionTd + "</tr>";
                $("#CourseExamTable").append(tr);
                
            });


        }


    });





});

$(document).on('click', '#deleteExam', function () {

    if (confirm("Do you want to Delete the row?")) {
        // your deletion code
        $(this).closest("tr").remove();
    }
    return false;

});

$(document).on('click', '#editExam', function () {
    $("#HiddenField").append("<input type='hidden' id='Id' name='Id'/>");
    var row = $(this).closest("tr").index();

    var examId = document.getElementById("CourseExamTable").rows[row].cells[0].innerText;
    var topic = document.getElementById("CourseExamTable").rows[row].cells[2].innerText;
    var fullMarks = document.getElementById("CourseExamTable").rows[row].cells[5].innerText;
    var examCode = document.getElementById("CourseExamTable").rows[row].cells[3].innerText;
    var examType = document.getElementById("CourseExamTable").rows[row].cells[1].innerText;
    var time = document.getElementById("CourseExamTable").rows[row].cells[4].innerText;
    var minute = time.substring(time.indexOf(":") + 1);
    var hour = time.substring(0, time.indexOf(":"));

    $("#rowIndex").val(row);
    $("#Id").val(examId);
    $("#Topic").val(topic);
    $("#FullMarks").val(fullMarks);
    $("#Hour").val(hour);
    $("#Minute").val(minute);
    $("#ExamCode").val(examCode);
    $("#ExamTypeDD").val(examType).trigger("chosen:updated");
   
   // $("#ExamTypeDD").val(examType).attr("selected", "selected");
    $("#SaveExamButton").val('Update');
    //$('#SaveExamButton').attr('id', 'UpdateExamButton');
    



});



$(function () {
    // Delegating to `document` just in case.
    $(document).on("hidden.bs.modal", "#OptionModal", function () {
        $(this).find("#OptionsModal").html(""); // Just clear the contents.
        //  $(this).find("#OptionsModal").remove(); // Remove from DOM.
    });
});