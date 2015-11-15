﻿$(function() {
    $("#box").combogrid({
        panelWidth: 600,
        idField: "Id",
        textField: "UserName",
        url: '/EasyUI/Index34Info',
        columns: [[
            { field: 'UserName', title: '账号', width: 120 },
            { field: 'Email', title: '电子邮件', width: 120 },
            { field: 'Create', title: '创建日期', width: 120 }
        ]]
    });
});