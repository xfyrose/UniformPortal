$(function() {
    $("#login").dialog({
        title: "登录后台",
        width: 300,
        height: 180,
        modal: true,
        iconCls: "icon-search",
        buttons: "#btn"
    });

    $("#manager").validatebox({
        required: true,
        missingMessage: "请输入管理员账号",
        invalidMessage: "管理员账号不可为空"
    });

    $("#password").validatebox({
        required: true,
        validType: "length[6, 30]",
        missingMessage: "请输入管理员密码"
        //invalidMessage: "管理员密码不可为空"
    });

    if (!$("#manager").validatebox("isValid")) {
        $("#manager").focus();
    } else if (!$("#password").validatebox("isValid")) {
        $("#password").focus();
    }

    $("#btn a").click(function () {
        if (!$("#manager").validatebox("isValid")) {
            $("#manager").focus();
        } else if (!$("#password").validatebox("isValid")) {
            $("#password").focus();
        } else {
            $.ajax(
            {
                url: "Index39CheckLogin",
                datatype: "text",
                type: "POST",
                data: {
                    manager: $("#manager").val(),
                    password: $("#password").val()
                },
                beforeSend: function() {
                    $.messager.progress({
                        text: "正在登录..."
                    });
                },
                success: function(data, response, status) {
                    $.messager.progress("close");
                    alert("bbb");
                    console.log(data);
                    if (data === 'true') {
                        location.href = "/EasyUI/Index39Admin";
                    } else {
                        $.messager.alert("登录失败", "用户名或密码错误", "warning", function() {
                            $("#password").select();
                        });
                    }
                }
            });
        }
    });
});