$(function() {
    $("#box").slider({
        value: 12,
        showTip: true,
        rule: [0, '|', 25, '|', 50, '|', 75, '|', 100],
    });
});