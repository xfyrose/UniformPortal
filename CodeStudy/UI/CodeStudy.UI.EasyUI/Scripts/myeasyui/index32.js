var obj = {
    editRow: undefined,

    search: function () {
        $("#box").datagrid("load", {
            UserName: $.trim($("input[name='UserName']").val())
        });
    },

    add: function () {
        //$("#box").datagrid("appendRow", {
        //    UserName: "bnbbs",
        //    Email: "bnbbs@163.com",
        //    Create: "2015-10-10"
        //});
        if (this.editRow == undefined) {
            $("#save, #redo").show();

            $("#box").datagrid("insertRow", {
                index: 0,
                row: {
                    //UserName: "bnbbs",
                    //Email: "bnbbs@163.com",
                    //Create: "2015-10-10"
                }
            });

            $("#box").datagrid("beginEdit", 0);
            this.editRow = 0;
        }
    },

    save: function() {
        $("#box").datagrid("endEdit", this.editRow);
    },

    redo: function() {
        $("#box").datagrid("rejectChanges");
        $("#save, #redo").hide();
        this.editRow = undefined;
    },

    edit: function() {
        var rows = $("#box").datagrid("getSelections");
        
        if (rows.length == 1) {
            if (this.editRow != undefined) {
                $("#box").datagrid("endEdit", this.editRow);
                this.editRow = undefined;
            }

            if (this.editRow == undefined) {
                var index = $("#box").datagrid("getRowIndex", rows[0]);

                $("#box").datagrid("beginEdit", index);
                $("#save, #redo").show();
                this.editRow = index;
                $("#box").datagrid("unselectRow", index);
            }
        } else {
            $.messager.alert("警告", "未选或多选");
        }
    },

    remove: function() {
        var rows = $("#box").datagrid("getSelections");

        if (rows.length > 0) {
            $.messager.confirm("确定操作", "删除？", function(flag) {
                if (flag) {
                    var ids = [];
                    for (var i = 0; i < rows.length; i++) {
                        ids.push(rows[i].UserName);
                    }
                    //console.log(ids.join(","));

                    $.ajax({
                        type: "POST",
                        url: "/EasyUI/Index32Delete",
                        data: {
                            ids: ids.join(",")
                        },
                        beforeSend: function(jqXHR, settings) {
                            $("#box").datagrid("loading");
                        },
                        
                        success: function (data, textStatus, jqXHR) {
                            console.log("remove finished:");
                            console.log(data);
                            if (data) {
                                $("#box").datagrid("loaded");
                                $("#box").datagrid("reload");
                                $("#box").datagrid("unselectAll");
                                $.messager.show({
                                    title: "提示",
                                    msg: data + " 个删除"
                                });
                            }
                        }
                    });
                }
            });
        } else {
            $.messager.alert("警告", "未选");
        }

    }
};

$(function () {
    $("#box").datagrid({
        width: 600,
        url: "/EasyUI/Index32Info",
        title: "用户列表",
        iconCls: "icon-search",
        striped: true,
        loadMsg: "正在加载数据",
        rownumbers: true,
        rowStyler: function(index, row) {
            //console.log(index);
            //console.log(row);
            //if (row.UserName == "蜡笔小新") {
            //    return "background-color:#ff0000";
            //} else {
            //    return "";
            //};
        },
        columns: [
            [

                {
                    field: "UserName",
                    title: "账号",
                    //checkbox: true
                    width: 200,
                    sortable: true,
                    editor: {
                        type: "validatebox",
                        options: {
                            required: true
                        }
                    },
                    formatter: function(value, rowData, rowIndex) {
                        return "[" + value + "]";
                    }
                },
                {
                    field: "Email",
                    title: "邮件",
                    sortable: true,
                    editor: {
                        type: "validatebox",
                        options: {
                            required: true,
                            validType: "email"
                        }
                    }
                },
                {
                    field: "Create",
                    title: "注册时间",
                    sortable: true,
                    editor: {
                        type: "datetimebox",
                        options: {
                            required: true,
                            editable: false
                        }
                    }
                }
            ]
        ],

        pagination: true,
        pageSize: 5,
        pageList: [5, 10, 15],
        pageNumber: 1,
        pagePosition: "bottom",
        sortName: "Create",
        sortOrder: "DESC",
        toolbar: "#tb",
        onAfterEdit: function(rowIndex, rowData, changes) {
            $("#save, #redo").hide();
            console.log("rowData:");
            console.log(rowData);

            var inserted = $("#box").datagrid("getChanges", "inserted");
            var updated = $("#box").datagrid("getChanges", "updated");

            console.log("inserted:");
            console.log(inserted);
            console.log("updated:");
            console.log(updated);

            if (inserted.length > 0) {
                $.ajax({
                    type: "POST",
                    url: "/EasyUI/Index32Add",
                    data: {
                        rows: inserted
                    },
                    beforeSend: function (jqXHR, settings) {
                        $("#box").datagrid("loading");
                    },
                    success: function (data, textStatus, jqXHR) {
                        console.log("add finished:");
                        console.log(data);
                        if (data) {
                            $("#box").datagrid("loaded");
                            $("#box").datagrid("reload");
                            $("#box").datagrid("unselectAll");
                            $.messager.show({
                                title: "提示",
                                msg: data + " 新建"
                            });

                            this.editRow = undefined;
                        }
                    }
                });
            }


            //console.log(rowIndex);
            //console.log(rowData);
            //console.log(changes);
        },

        onDblClickRow: function(rowIndex, rowData) {
            $("#save, #redo").show();

            if (obj.editRow != undefined) {
                $("#box").datagrid("endEdit", obj.editRow);
                obj.editRow = undefined;
            }

            if (obj.editRow == undefined) {
                $("#box").datagrid("beginEdit", rowIndex);
                $("#save, #redo").show();
                obj.editRow = rowIndex;
            }
        },

        onHeaderContextMenu: function(e, field) {
            console.log("Header Context Menu");
            console.log(e);
            console.log(field);
        },

        onRowContextMenu: function(e, rowIndex, rowData) {
            e.preventDefault();
            console.log("Row Context Menu");
            console.log(rowData);

            $("#rowmenu").menu("show", {
                left: e.pageX,
                top: e.pageY
            });
        },

        onClickRow: function(rowIndex, rowData) {
            console.log(rowData);
        }
    });
});

$.extend($.fn.datagrid.defaults.editors, {
    datetimebox: {
        init: function (container, options) {
            var input = $("<input type='text'>").appendTo(container);
            options.editable = false;
            input.datetimebox(options);
            return input;
        },
        getValue: function (target) {
            return $(target).datetimebox("getValue");
        },
        setValue: function (target, value) {
            $(target).datetimebox("setValue", value);
        },
        resize: function (target, width) {
            $(target).datetimebox("resize", width);
        },
        destroy: function (target) {
            $(target).datetimebox("destroy");
        }
    }
});