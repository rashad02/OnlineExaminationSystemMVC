

//$(document).ready(function() {

//    $.ajax({
//        type: "POST",
//        url: "../../Exam/GetQuestion",
//        contentType: "application/Json; charset=utf-8",
//        data: JSON.stringify(),
//        dataType: 'json',
//        success: function (result) {
//            // alert(result);
          


//        }
//    });

//});


$(document).ready(function () {
   
    $('#OptionModal').on('hidden', function () {
        clear();
    });


    $.ajax({
        type: "POST",
        url: "../../Exam/GetQuestion",
        dataType: "json",
        
        data: JSON.stringify(),
        success: function (data) {
            $.each(data, function (k, v) {

                var options = v.QuestionData.length;
                var qId = v.Id;
                var qOrderTd = "<td>" + v.QuestionOrder + "</td>";
                var question = " <td> " + v.QuestionText + "</td>";
                var questionOptions = '<td ><a href="#" id="' + qId + '" onclick="onOptionClick()">' + options + '</a></td>';
                var questionMarks = "<td> " + v.Marks + "</td>";
                var action = '<td><a class="teal-text"><i class="glyphicon glyphicon-pencil" ></i></i></a>   <a class="red-text"><i class="glyphicon glyphicon-remove" aria-hidden="true"></i></a></td>';


                var tr = '<tr>' +qOrderTd+ question + questionOptions + questionMarks + action + '</tr>';

                $('#QuestionDetailsBody').append(tr);
          
            });
        },
        error: function(result) {
            alert(result);
        }

    });
});



function onOptionClick() {
    //var getIdFromRow = $(event.target.id);
   
    var data = $(event.target).attr('id');
    $.ajax({
        type: "POST",
        url: "../../Exam/GetOptionByQuestionId",
        dataType: "json",
        contentType: "application/Json; charset=utf-8",
        data: JSON.stringify({ id: data }),
        success: function(result) {
            $.each(result, function (k, v) {



                var oOrder = "<td>" + v.OptionOder + "</td>";
                var oIsAnswer = "<td>" + v.IsAnswer + "</td>";
                var oText = "<td>" + v.OptionText + "</td>";

                var tr = '<tr>' + oOrder + oIsAnswer + oText + '</tr>';

                $("#OptionsModal").append(tr);

                
               
            });
            
            
        }
    });
    $('#OptionModal').modal('show');
    
}


$(function () {
  // Delegating to `document` just in case.
    $(document).on("hidden.bs.modal", "#OptionModal", function () {
        $(this).find("#OptionsModal").html(""); // Just clear the contents.
      //  $(this).find("#OptionsModal").remove(); // Remove from DOM.
  });
});