$(function() {
    $("#box").dialog({
        title: "对话框",
        iconCls: 'icon-save',
        modal: true,
        //toolbar: '#tt'
        toolbar: [
        {
            text: "编辑",
            iconCls: 'icon-edit',
            handler: function() {
                alert("edit");
            }
        }, {
            
        }],
        buttons : [{
            text:"确定",
            iconCls:'icon-ok',
            handler:function() {
                alert("ok");
            }
        }, {
            text: "取消",
            iconCls: 'icon-cancel',
            handler:function() {
                alert("cancel");
            }
        }]
    });

    console.log("1");
    console.log($("#box").dialog("dialog"));
    console.log("2");
});