$(function() {
    $("#box").panel({
        width: 300,
        height: 150,
        title: "面板",
        closable: false,
        iconCls: 'icon-search',
        //fit: true,
        content: "新内容",
        collapsible: true,
        minimizable: true,
        maximizable: true,
        tools: [
        {
            iconCls: "icon-help",
            handler: function() {
                alert("help!");
            }
        }],
        href: "/EasyUI/Index09_1",
        loadingMessage: "加载中...",
        extractor: function(data) {
            return data.substring(1);
        },
        //onBeforeLoad: function() {
        //    alert("远程加载之前出发！");
        //},
        //onLoad: function () {
        //    alert("远程加载之后出发！");
        //}
        onResize: function(width, height) {
            alert(width + " | " + height);
        }
    });

    //$(document).click(function() {
    //    $("#box").panel("resize", {
    //        width: 600,
    //        height: 300
    //    });
    //});
    console.log($("#box").panel("options"));
    console.log($("#box").panel("panel"));
    console.log($("#box").panel("header"));
    console.log($("#box").panel("body"));
    $("#box").panel("setTitle", "标题设置");
});