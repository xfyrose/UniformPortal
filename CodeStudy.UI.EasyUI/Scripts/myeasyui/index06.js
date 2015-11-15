$(function() {
    $("#box").tooltip({
        content: "这里可以输入提示内容",
    });
});

$("#box").click(function() {
    $(this).tooltip("update", "改变了");
    console.log($(this));
    console.log(this);
});