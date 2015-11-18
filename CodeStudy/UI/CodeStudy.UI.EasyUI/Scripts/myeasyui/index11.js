$(function() {
    $("#box").accordion({
        //width: 500,
        //height: 300,
        //fit: true
        //onSelect: function(title, index) {
        //    alert(title + " | " + index);
        //}
    }).hide();

    $("#box").accordion().show();

    $(document).click(function() {
        $("#box").accordion("resize");
    });

    console.log($("#box").accordion("options"));
    console.log($("#box").accordion("panels"));
});