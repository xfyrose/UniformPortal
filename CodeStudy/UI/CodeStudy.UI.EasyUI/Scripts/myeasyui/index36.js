$(function() {
    $("#box").tree({
        url: "/EasyUI/Index36Tree",
        lines: true,
        onLoadSuccess: function(node, data) {
        },

        onClick: function (node) {
            console.log("Click");
            console.log(node);
        }
    });
});