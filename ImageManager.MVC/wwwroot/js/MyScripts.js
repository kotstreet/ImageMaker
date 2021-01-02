
$(function () {
    $.ajaxSetup({ cache: false });
    $(".delItem").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
})

$(document).ready(function () {
    $("#generalInfo").on("hide.bs.collapse", function () {
        $(".btn-collapse").html('Показать общую статистику <i class="fas fa-chevron-down"></i>');
    });
    $("#generalInfo").on("show.bs.collapse", function () {
        $(".btn-collapse").html('Скрыть общую статистику <i class="fas fa-chevron-up"></i>');
    });
});


$(function () {
    $.ajaxSetup({ cache: false });
    $(".delItem").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContentDelete').html(data);
            $('#modDialogDelete').modal('show');
        });
    });
})

$(function () {
    $.ajaxSetup({ cache: false });
    $(".carryItem").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContentCarry').html(data);
            $('#modDialogCarry').modal('show');
        });
    });
})

