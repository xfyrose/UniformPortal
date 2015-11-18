$(function() {
    $("#manager").datagrid({
        url: "/EasyUI/Index32Info",
        fit: true,
        fitColumns: true,
        striped: true,
        rownumbers: true,
        border: false,
        pagination: true,
        pageSize: 3,
        pageList: [3, 6, 9],
        pageNumber: 1,
        sortName: "UserName",
        sortOrder: "DESC",
        toolbar: "#manager_tool",
        columns: [[
            {
                field: "Id",
                title: "用户编号",
                width: 100,
                checkbox: true
            },
            {
                field: "UserName",
                title: "用户名",
                width: 100
            },
            {
                field: "Email",
                title: "电子邮件",
                width: 100
            },
            {
                field: "Create",
                title: "创建日期",
                width: 100
            }
        ]]
    });
});