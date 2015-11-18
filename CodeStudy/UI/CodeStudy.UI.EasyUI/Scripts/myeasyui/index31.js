$("#box").form({
    url: "/EasyUI/Index31Content",
    onSubmit: function(param) {
        param.code = "340104";
    },
    success: function(data) {
        alert(data);
        var info = eval("(" + data + ")");
        alert(info);
        if (info.Name) {
            alert(info.Name);
            alert(info.Code);
            alert(info.Email);
        }
    }
});

$("#box").form("load", {
    name: "wu",
    email: "a@a.com"

});