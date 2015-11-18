$(function() {
    $("#box").progressbar({
        value: 20,
        onChange : function(newValue, oldValue) {
            console.log("新:" + newValue + " 旧:" + oldValue);
        }
    });
})

//setTimeout(function() {
//    $("#box").progressbar("setValue", 80);
//}, 1000);

setInterval(function() {
    $("#box").progressbar("setValue", $("#box").progressbar("getValue") + 5);
}, 500)