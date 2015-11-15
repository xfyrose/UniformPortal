$(function() {
    $("#box").combo({
        required: true,
        multiple: true
    });

    $("#food").appendTo($("#box").combo("panel"));

    console.log($("#box").combo("panel"));

    $("#food input").click(function() {
        var v = $(this).val();
        var s = $(this).next("span").text();
        console.log(this);
        console.log($(this));
        $("#box").combo("setValue", v).combo("setText", s).combo("hidePanel");

        console.log($("#box").combo("getValues"));
    });
});