$(function() {
    $("#ss").searchbox({
        searcher: function(value, name) {
            alert(value + "," + name);
        },
        menu: "#box",
        prompt: "请输入内容"
    });

    console.log($("#ss").searchbox("menu"));

    var m = $("#ss").searchbox("menu");
    m.menu("setIcon", {
        target: m.menu("findItem", "Sports News").target,
        iconCls: 'icon-edit'
    });

    console.log($("#ss").searchbox("textbox"));

});