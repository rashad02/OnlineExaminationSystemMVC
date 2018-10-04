$(document).ready(function() {
    tinymce.init({
        selector: '#Question',
        
        height: 172,
        statusbar: false
    });

});


$(function () {
    $('input[name="Answer"]').click(function () {
        var $radio = $(this);

        // if this was previously checked
        if ($radio.data('waschecked') == true) {
            $radio.prop('checked', false);
            $radio.data('waschecked', false);
        }
        else
            $radio.data('waschecked', true);

        // remove was checked from other radios
       // $radio.siblings('input[type="radio"]').data('waschecked', false);
    });
});


$("#AddButtonOption").click(function () {
    var order = $('#Order').val();
    var answer = $("input[name='Answer']:checked").val();
    var answerText = $('#OptionText').val();
    

    var slTd = "<td>" + order + "</td>";
    var answerTd = "";
    if (answer=="on") {
         answerTd = '<td><input type="radio" checked ';
    } else {
         answerTd = '<td><input type="radio" ';
    }
    
    var answerTextTd = " <p> " + answerText + " </p> </td>";
    var actionTd = '<td><a href="#">Remove</a></td>';
   
    var tr = "<tr>" + slTd + answerTd + answerTextTd + actionTd + "</tr>";

    $('#OptionAddedBody').append(tr);
    $('#Answer').attr('checked', false);

});



$("#SubmitQAButton").click(function () {


    var marks = $("#Marks").val();
    var questionOrder = $("#QuestionOrder").val();
   // var text = tinymce.get("#Question").getContent({ format: "text" });
    var questionText = tinyMCE.activeEditor.getContent({format:'text'});
    //var questionText = "";
    //$(questionText).append($.parseHTML(text));
    var examId = $("#ExamTypeDD option:selected").val();

    var optionList = [];
    var optionText;

    $("#OptionTable tr:not(:first)").each(function () {
        var index = (this.rowIndex);
        var tdlist = $(this).find("td");
        var radiolist = $(this).find("input:radio:checked");
        if ($(radiolist[0]).val() == "on") {
            optionText = true;
        } else {
            optionText = false;
        }
        var item = {
            OptionOder: $(tdlist[0]).text(),
            IsAnswer: optionText,
            OptionText: $(tdlist[1]).text() 
        };
        
        optionList.push(item);
    });

    var question = {
        Marks: marks,
        QuestionOrder: questionOrder,
        QuestionText: questionText,
        ExamsId: examId,
        QuestionAnswers: optionList
    };

    $.ajax({
        type: "POST",
        url: "../../Exam/QuestionAnswerEntry",
        contentType: "application/Json; charset=utf-8",
        data: JSON.stringify({ question: question }),


        success: function () {     
            window.location.href = "http://localhost:1093/Exam/QuestionSummary";
        } 

    });

   



    //var slTd = "<td>" + order + "</td>";
    //var answerTd = "";
    //if (answer == "on") {
    //    answerTd = '<td><input type="radio" checked ';
    //} else {
    //    answerTd = '<td><input type="radio" ';
    //}

    //var answerTextTd = " <p> " + answerText + " </p> </td>";
    //var actionTd = '<td><a href="#">Remove</a></td>';

    //var tr = "<tr>" + slTd + answerTd + answerTextTd + actionTd + "</tr>";

    //$('#OptionAddedBody').append(tr);
    //$('#Answer').attr('checked', false);

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
            $("#CourseDD").append("<option value=''>---Select---</option>");
            if (rData != undefined && rData != "") {
                $.each(rData, function (k, v) {
                    $("#CourseDD").append("<option value='" + v.Id + "'>" + v.CourseName + "</option>");
                });

            }
        }


    });

});

$('#CourseDD').change(function () {

    var courseId = $(this).val();

    var params = { id: courseId }
    $.ajax({

        //Type Get/ Post
        type: "POST",

        //Url / Link
        url: "../../Exam/GetExamCodeByCourseId",

        //Convert Type To Json Format 
        contentType: "application/Json; charset=utf-8",

        //Convert Parameter From Js Object To JSon Object
        data: JSON.stringify(params),
        dataType: 'json',
        //Call back Function With Response Data
        success: function (rData) {
            $("#ExamTypeDD").empty();
            $("#ExamTypeDD").append("<option value=''>---Select---</option>");
            if (rData != undefined && rData != "") {
                $.each(rData, function (k, v) {
                    $("#ExamTypeDD").append("<option value='" + v.Id + "'>" + v.ExamCode + "</option>");
                });

            }
        }


    });

});