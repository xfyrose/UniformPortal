$(function () {
    $("#box").menu({
        onShow: function() {
            alert('Show');
        },
        onHide: function() {
            alert('Hide');
        }
    });

    $(document).on("contextmenu", function(e) {
        e.preventDefault();

        $("#box").menu("show", {
            left: e.pageX,
            top: e.pageY
        });
    });

    //console.log($("#box").menu('options'));
    //console.log($("#box").menu("getItem", '#new'));

    //$("#box").menu("setText", {
    //    target: "#new",
    //    text: "新新"
    //});

    console.log($("#box").menu("findItem", "退出"));

    $("#box").menu("appendItem", {
        text: "new append",
        iconCls: "icon-add",
        href: "123.html",
        onclick: function() {
            alert("new append");
        }
    });
});