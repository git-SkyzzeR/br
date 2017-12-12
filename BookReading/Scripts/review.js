function replacer(str, offset, s) {
    var res = ""
    for (var j = 1; j < str.length; j++) {
        res += "#";
    }
    return res;
}

$('form').on('submit', function () {
    var library = ["qwe", "asd", "zxc"];
    var authorName = $('#Name').val();
    var textReview = $('#Text').val();
    for (var i = 0; i < library.length; i++) {
        if (textReview.indexOf(library[i]) !== -1) {
            var result = confirm("Нецензурная лексика, хотите заменить?")
            if (result) {
                var reg = new RegExp(library.join('|'), "gi");
                $('#Text').val(textReview.replace(reg, replacer));
            }
            else {
                return false;
            }
        }
    }
    return true;
});