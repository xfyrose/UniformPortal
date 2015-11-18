$(function() {
    $("#box").numberbox({
        min: 0,
        precision: 2,
        filter: function(e) {
            console.log(e);
        },
        formatter: function(value) {
            return "111," + value;
        }
    });
});