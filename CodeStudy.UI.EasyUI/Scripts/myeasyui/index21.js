$(function() {
    $("#email").validatebox({
        required: true,
        //validType: "email",
        validType: "remote['/EasyUI/Index21Valid', 'abc']"
    });

    console.log($("#email").validatebox("options"));
});