$(function () {
    $("#content").panel({
        href: "/EasyUI/Index19User"
    });

    $("#box").pagination({
        total: 11,
        pageSize: 1,
        pageNumber: 1,
        pageList: [1, 2, 3],
        //loading: true,
        buttons: [
        {
            iconCls: "icon-add"
        },
        "-",
        {
            iconCls: "icon-edit"
        }],
        onSelectPage: function (pageNumber, pageSize) {
            $("#box").pagination("loading");

            $("#content").panel("refresh", "/EasyUI/Index19User?pageNumber=" + pageNumber + "&pageSize=" + pageSize);

            setTimeout(function() {
                $("#box").pagination("loaded");
            }, 3000);
        }
    });
})