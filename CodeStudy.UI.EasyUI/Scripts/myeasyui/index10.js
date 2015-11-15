$(function() {
    $("#box").tabs({
        tools: [
        {
            iconCls: "icon-add",
            handler: function() {
                alert("add");
            }
        },
        {
            iconCls: "icon-edit",
            handler: function() {
                alert("edit");
            }
        }],

        //onSelect: function(title, index) {
        //    alert(title + " | " + index);
        //},

        //onContextMenu: function(e, title, index) {
        //    console.log(e);
        //    console.log(title + " | " + index);
        //}

        //onAdd: function(title, index) {
        //    alert(title + " | " + index);
        //},

        //onLoad: function(panel) {
        //    alert(panel);
        //},

        onUpdate: function(title, index) {
            alert(title + " | " + index);
        }
    });

    $("#box").tabs("add", {
        id: "tab4",
        title: "新加tab",
        content: "tab4",
        iconCls: "icon-add"
    });

    $("#box").tabs("update", {
        tab: $("#tab2"),
        options: {
            title: "新tab2"
        }
    });

    //$(document).click(function() {
    //    $("#box").css("display", "block");
    //    //$("#box").tabs().css("display", "block");
    //});

    //console.log($("#box").tabs("tabs"));
});