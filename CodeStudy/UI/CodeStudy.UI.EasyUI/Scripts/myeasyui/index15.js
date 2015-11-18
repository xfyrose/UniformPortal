$(function() {
    //$.messager.alert("alert", "alert content", "info", function() {
    //    alert("finish");
    //});

    //$.messager.confirm("confirm", "delete?", function(flag) {
    //    if (flag) {
    //        alert("delete success!");
    //    }
    //});

    //$.messager.prompt("prompt", "please input:", function(content) {
    //    if (content) {
    //        alert(content);
    //    }
    //});

    //$.messager.progress({
    //    title: "executing",
    //    msg: "upload",
    //    text: "{value}%",
    //    interval: 100
    //});

    //console.log($.messager.progress("bar"));
    //$.messager.progress("close");

    $.messager.show({
        title: "my show",
        msg: "xiaoxi",
        time: 5000,
        showType: "fade",
        style: {
            top: 0
        }
    });
});