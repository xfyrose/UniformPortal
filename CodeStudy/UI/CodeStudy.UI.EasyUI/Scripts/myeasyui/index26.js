$(function() {
    $("#box").spinner({
        onSpinUp: function() {
            $("#box").spinner('setvalue', parseInt($("#box").spinner("getValue")) + 1);
        },
        onSpinDown: function () {
            $("#box").spinner('setValue', parseInt($("#box").spinner("getValue")) - 1);
        }
    });
});