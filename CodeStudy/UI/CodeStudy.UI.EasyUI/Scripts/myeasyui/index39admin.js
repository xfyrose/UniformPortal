$(function () {
    $("#nav").tree({
        url: "/EasyUI/Index39Menu",
        lines: true,
        onLoadSuccess: function(node, data) {
            if (data) {
                $(data).each(function(index, value) {
                    if (this.state === "closed") {
                        $("#nav").tree("expandAll");
                    }
                });
            }
        },
        onClick: function(node) {
            if (node.Url) {
                if ($("#tabs").tabs("exists", node.text)) {
                    $("#tabs").tabs("select", node.text);
                } else {
                    $("#tabs").tabs("add", {
                        title: node.text,
                        iconCls: node.iconCls,
                        closable: true,
                        href: node.Url
                    });
                }
            }
        }
    });


    $("#tabs").tabs({
        fit: true,
        border: false
    });
});