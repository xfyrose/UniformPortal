$(function() {
    $("#box").combobox({
        valueField: "Id",
        textField: "User",
        url: "/EasyUI/Index33Info",

        mode: "remote",

        filter: function(q, row) {
            var opts = $(this).combobox("options");
            return row[opts.textField].indexOf(q) >= 0;
        }
    });
});