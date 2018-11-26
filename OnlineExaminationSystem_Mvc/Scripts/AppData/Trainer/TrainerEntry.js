$(function () {
    $("#OrganizationDD").change(function () {
        $("#OrganizationId").val($(this));
    });
});
$(function () {
    $("#CourseDD").change(function () {
        $("#CourseId").val($(this));
    });
});


function onChangeSuccess(data) {
  
    if (data.status == failure) {
        $.each(data.formErrors, function () {
            $("[data-valmsg-for=" + this.key + "]").html(this.errors.join());
        });
    };


};