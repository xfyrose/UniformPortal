///<reference path="jquery.validate.js" />
///<reference path="jquery.validate.unobtrusive.js" />

$.validator.unobtrusive.adapters.addSingleVal("maxwords", "wordcount");

$.validator.addMethod("maxwords", function(vale, element, maxwords) {
    if (value) {
        if (value.Split(' ').length > maxwords) {
            return false;
        }
    }
})