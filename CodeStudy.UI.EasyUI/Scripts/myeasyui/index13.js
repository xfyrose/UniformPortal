$(function() {
    $("#box").window({
        iconCls: 'icon-save',
        model: true,
        title: "My My Window 2"
    });

    console.log(1);
    console.log($("#box").window("window"));
    console.log(2);
});