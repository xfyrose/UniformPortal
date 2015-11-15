$(function() {
    $("#box").draggable({
        //revert: true,
        //cursor: "text",
        //handle: "#pox",
        //disabled: true,
        //edge: 80,
        //axis: 'v'，
        //proxy: 'clone',
        //deltaX: 10,
        //deltaY: 10,
        //proxy: function(source) {
        //    //var p = $('<div style="width:400px;height:200px;border:1px dashed #ccc" />');
        //    //p.html($(source).html()).appendTo('body');
        //    //return p;
        //    console.log(source);
        //    console.log($(source));
        //}
        //onBeforeDrag : function(e) {
        //    console.log(e);
        //    alert("BeforeDrag");
        //}
        //onStartDrag: function (e) {
        //    console.log($("#box").draggable("options"));
        //    console.log($("#box").draggable("proxy"));
        //}
    });

    console.log($("#box").draggable("options"));
})