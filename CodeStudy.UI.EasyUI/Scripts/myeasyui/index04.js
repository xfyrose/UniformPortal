$(function () {
    $("#dd").droppable({
        //accept: "#box",
        //disabled: true,
        onDragEnter: function(e, source) {
            $(this).css("background", "orange");
            console.log(e);
            console.log(source);
        }
    });

    console.log($("#dd").droppable("options"));
    console.log($("#box").droppable("options"));

    $("#box").draggable();
})