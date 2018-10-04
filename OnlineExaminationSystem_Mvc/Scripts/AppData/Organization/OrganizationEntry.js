$("#Name").change(function() {
    var organizationName = $("#Name").val();
    var code = "Org-" + organizationName;
    $("#Code").val(code);

});

$(document).ready(function() {

    $.ajax({
        type: "Post",
        url: "../../Organization/GetOrganization",
        dataType: 'json',
        contentType: "application/json charset=utf-8",
        success: function (data) {
            var i = 1;
            $.each(data, function (k, v) {
                var studentTd = "";
                var trainerTd = "";
                var slTd = "<td> " + i + " </td>";
                var nameTd = "<td> " + v.Name + " </td>";
                var codeTd = "<td> " + v.Code + " </td>";
                studentTd = "<td> " + v.StudentData + " </td>";
               trainerTd = "<td> " + v.TrainerData + " </td>";
               
                
               
                var actionTd = '<td> <a href="#">Edit</a> || <a href="#">Delete</a> </td>';
                var tr = "<tr> " + slTd + nameTd + codeTd + trainerTd + studentTd + actionTd + "</tr>";
                i++;
                $("#OrganizationViewTableContent").append(tr);
            });
        }
})

});