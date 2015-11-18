$(function() {
    $("#box").layout({
        //fit: true
    }).css("display", "none");
});

$(document).click(function() {
    $("#box").layout().css("display", "block");
    $("#box").layout("resize");
});