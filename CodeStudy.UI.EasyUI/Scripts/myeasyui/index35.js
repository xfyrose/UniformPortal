$(function() {
    $("#box").propertygrid({
        url: "/EasyUI/Index35Info",
        showGroup: true,
        groupFormatter: function(group, row) {
            return "[" + group + "]";
        }
    });
});