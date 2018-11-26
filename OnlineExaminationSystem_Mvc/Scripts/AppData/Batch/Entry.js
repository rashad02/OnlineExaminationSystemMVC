
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


$(function () {
    $('#startDateTimePicker').datetimepicker();
});
$(function () {
    $('#endDateTimePicker').datetimepicker();
});

$(function () {
    $('#examDateTimePicker').datetimepicker();
});


$('#AddTrainerButton').click(function () {
    var trainerName = $('#Trainer option:selected').text();
    var trainerId = $('#Trainer option:selected').val();
    var index = $('#tranierDetailsBody').children('tr').length;

    var indexTd = "<td> " + (index + 1) + "</td>";

    var nameTd = "<td id=" + trainerId + ">" + trainerName + "</td>";
    var radio = '<td> <input type="radio" id="leadTrainerRadio' + (index + 1) + '" /></td>';
    var action = '<td><a href="#" id="editLink" >Edit</a> | <a href="#" id="deleteLink">Delete</a></td>';
    var newRow = "<tr>'" + indexTd + nameTd + radio + action + "'</tr>";
    $('#tranierDetailsBody').append(newRow);

});

$('#AddStudentButton').click(function () {
   // var trainerName = $('#StudentDD option:selected').text();
    var studentId = $('#StudentDD option:selected').val();
    var index = $('#studentsDetailsBody').children('tr').length;
    $.ajax({
        //Convert Parameter From Js Object To JSon Object
        //Type Get/ Post
        type: "POST",
        //Url / Link
        url: "../../Batch/GetStudentById",
        data: JSON.stringify({ id: studentId }),
        contentType: "application/Json; charset=utf-8",
        //Convert Type To Json Format 
        //Call back Function With Response Data
        success: function (result) {
            var indexTd = "<td> " + (index + 1) + "</td>";
            var nameTd = "<td id=" + result.Id + ">" + result.Name + "</td>";
            var professionTd = '<td id=' + result.Id + '> '+ result.Profession+'</td>';
            var action = '<td><a href="#" id="editLink" >Edit</a> | <a href="#" id="deleteLink">Delete</a></td>';
            var newRow = "<tr>'" + indexTd + nameTd + professionTd + action + "'</tr>";
            $('#studentsDetailsBody').append(newRow);
        }
    });
});


$(document).on('click', '#deleteLink', function () {
    if (confirm("Do you want to Delete the row?")) {
        // your deletion code
        $(this).closest("tr").remove();
    }
    return false;

});




$(document).on('click', '#editLink', function () {
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
        success: function (result) {
            $('#modalContent').html(result);
            $('#OptionModal').modal('show');
        }

    });

});


function onBatchSuccess(data) {
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


$('#SaveTrainerButton').click(function () {
    var TrainerList = [];
    var trainerType = 0;

    $("table tr:not(:first)").each(function () {
        var index = (this.rowIndex);
        if (index == 0) {
            return;
        }
        var tdlist = $(this).find("td");
        var Item = {
            Name: $(tdlist[1]).text()
        };
        TrainerList.push(Item);
        trainerType = GetTrainerType(index);
    });

    var batchEntryVm = { Trainers: TrainerList, TrainerType: trainerType };

    $.ajax({

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify({ 'batchEntryVm': batchEntryVm }),
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

$('#SaveStudentButton').click(function () {
    var studentList = [];
    var id = document.getElementById('Id').value;

    $("table tr:not(:first)").each(function () {
        var index = (this.rowIndex);
        if (index == 0) {
            return;
        }
        var tdlist = $(this).find("td");
        var item = {
            Id: $(tdlist[1]).attr('id'),
            Name: $(tdlist[1]).text(), 
            Profession: $(tdlist[2]).text()
        };
        studentList.push(item);
       // studentType = GetTrainerType(index);
    });

    var batchEntryVm = { Id:id,Students: studentList };

    $.ajax({

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify({ 'batchEntryVm': batchEntryVm }),
        contentType: "application/Json; charset=utf-8",
        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Batch/StudentAdded",
        dataType: 'json',
        //Convert Type To Json Format 
        //data: JSON.stringify(itemlist),




        //Call back Function With Response Data
        success: function () {
            alert("View Returns");
        }


    });



});

function onSaveSuccess(data) {


    $.ajax({
        type: "GET",
        url: "../../Batch/BatchExamAdd",
        contentType: "application/Json; charset=utf-8",
        success: function (result) {
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


$('#ScheduleExamButton').click(function() {
    var examId = $("#ExamDD option:selected").val();
    var examDate = $('#examDateTime').val();
    var exam= {
        Id: examId,
        ExamDate: examDate
    }

    $.ajax({

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify({ batchEntryVm: exam }),
        contentType: "application/Json; charset=utf-8",
        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Batch/ExamAssign",
        dataType: 'json',
        //Convert Type To Json Format 
        //data: JSON.stringify(itemlist),




        //Call back Function With Response Data
        success: function (result) {
            var typeTd = "";
            var topicTd = "";
            var codeTd = "";
            var durationTd = "";
            var fullMarksTd = "";
            $.each(result.Exam, function (k,v) {
               
               
                
                 typeTd = "<td> " + v.ExamType + "</td>";
                 topicTd = "<td> " + v.Topic + "</td>";
                 codeTd = "<td> " + v.ExamCode + "</td>";
                 durationTd = "";
                if (v.Duration.Hours < 10) {
                    durationTd = "<td> 0" + v.Duration.Hours + ":" + v.Duration.Minutes + "</td>";
                } else {
                    durationTd = "<td> " + v.Duration.Hours + ":" + v.Duration.Minutes + "</td>";
                }




                 fullMarksTd = "<td> " + v.FullMarks + "</td>";
            });
            var date = new Date(parseInt(result.ExamDate.replace('/Date(', ''))).toDateString();
            var time = new Date(parseInt(result.ExamDate.replace('/Date(', ''))).toLocaleTimeString();
            var scheduleTd = "<td> " + date + "  " + time + "</td>";
                var actionTd = '<td> <a href="#" id="editExam">Edit</a> | <a href="#" id="deleteExam">Delete</a></td>';
                var tr = "<tr> " + typeTd + topicTd + codeTd + durationTd + fullMarksTd +scheduleTd+ actionTd + "</tr>";
            

                $("#BatchOptionTable").append(tr);
                
          
        }

    });

    
});