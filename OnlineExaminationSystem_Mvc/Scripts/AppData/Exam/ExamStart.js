
$(document).ready(function () {
    document.getElementById("ActiveQuestionOrder").value = 1;
    
    $("#1").show();
});
$(function () {
    $('input[name="Answers"]').click(function () {
        var $radio = $(this);

        // if this was previously checked
        if ($radio.data('waschecked') == true) {
            $radio.prop('checked', false);
            $radio.data('waschecked', false);
        }
        else
            $radio.data('waschecked', true);

        // remove was checked from other radios
        $radio.siblings('input[type="radio"]').data('waschecked', false);
    });
});

   
var i;

$("#NextQuestionButton").click(function () {
    i = document.getElementById("NumberOfQuestion").value;
    var value = document.getElementById("ActiveQuestionOrder").value;
    document.getElementById(value).style.display = "none";
            var vale = parseInt(value) + 1;
            document.getElementById(vale).style.display = "inline";
            if (vale >= i) {
                document.getElementById("NextQuestionButton").disabled = true;
            }
            document.getElementById("ActiveQuestionOrder").value = vale;
             
   // $("#1").hide();
});

$("#PreviousQuestionButton").click(function () {
    i = document.getElementById("NumberOfQuestion").value;
    var value = document.getElementById("ActiveQuestionOrder").value;
   
    document.getElementById(value).style.display = "none";
    var vale = parseInt(value) - 1;
    document.getElementById(vale).style.display = "inline";
    if (vale <= 1) {
        document.getElementById("PreviousQuestionButton").disabled = true;
    }
    document.getElementById("ActiveQuestionOrder").value = vale;

});

//$("#SubmitQuestionButton").click(function () {
   
//    //   var value=$("div :active").attr('id');
//    var questionId = document.getElementById("ActiveQuestionOrder").value;
//    var answerList = [];
//    var chk = $('#OptionRadio input:radio:checked');
//    var answer = {
//        OptionText: chk.attr('value')
//    }
//    answerList.push(answer);

//   // var obtainedMarks = document.getElementById("ActiveQuestionId").value;
//   var value = document.getElementById("ActiveQuestionOrder").value;
//    //if (value == i) {
//    //    document.getElementById("NextQuestionButton").disabled = true;
//    //}
//    //document.getElementById(value).style.display = "none";

//    var question = { Id: questionId, QuestionOrder: value, QuestionAnswers: answerList }

//    $.ajax({
//        type: "POST",
//        url: "../../Exam/ExamResultCalculate",
//        contentType: "application/json charset=utf-8",
//        data: JSON.stringify({  Question: [question] }),
//        success: function () {
//            //var sum = document.getElementById("ObtainedMarksField").value;
//            //if (sum == "") {
//            //    document.getElementById("ObtainedMarksField").value = result;
//            //} else {
//            //    document.getElementById("ObtainedMarksField").value = parseInt(sum) + result;
//            //}
//           // window.location.href = "http://localhost:1093/Exam/ExamResultCalculate";

//            //var vale = parseInt(value) - 1;
//            //document.getElementById(vale).style.display = "inline";
//            //document.getElementById("ActiveQuestionOrder").value = vale;

//        }


//    });
//});

$("#SubmitQuestionButton").click(function () {
    var questionList=[];
    i = document.getElementById("NumberOfQuestion").value;
    var examId = document.getElementById("ExamsId").value;
    var studentId = document.getElementById("StudentId").value;
    var courseId = document.getElementById("CourseId").value;
    for (var j = 1; j <= i; j++) {
        var order = j;

        var answerList = [];
        var chk = $('#'+order+' input:radio:checked');
      // var chk = $("input[name='" + order + "']:checked");
        //var chk = $(order).is(":checked");
        var answer = {
            OptionText: chk.attr('value')
        }
        answerList.push(answer);
        var question = { ExamsId: examId, QuestionOrder: order, QuestionAnswers: answerList }
        questionList.push(question);
    }
    
    $.ajax({
            type: "POST",
            url: "../../Exam/EvaluateAnswers",
            contentType: "application/json charset=utf-8",
            data: JSON.stringify({ questions: questionList,StudentId:studentId,CourseId:courseId }),
            success: function() {

                window.location.href = "http://localhost:1093/Exam/ExamResult";

                //var sum = document.getElementById("ObtainedMarksField").value;
                //if (sum == "") {
                //    document.getElementById("ObtainedMarksField").value = result;
                //} else {
                //    document.getElementById("ObtainedMarksField").value = parseInt(sum) + result;
                //}
                // window.location.href = "http://localhost:1093/Exam/ExamResultCalculate";

                //var vale = parseInt(value) - 1;
                //document.getElementById(vale).style.display = "inline";
                //document.getElementById("ActiveQuestionOrder").value = vale;

            }


        });
    
});
