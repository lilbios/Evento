$("#tag-input").keypress(function (e) {
    if (e.keyCode == 32) {
        let tagValue = $("#tag-input").val().trim();
        let tagContainer = $("#tag-container");
        let content = $("#tags").val().split(',').filter(tags => tags != "");
        if (tagValue) {
            tagValue = "#" + tagValue;
            if (content.length < 5) {
                $("#msg").remove();

                if (!content.includes(tagValue)) {
                    content.push(tagValue);
                    content.join(",");
                    tagContainer.append('<small class="badge badge-warning" style="margin-left: 5px">' + tagValue + '</small>');
                    $("#tags").val(content);
                    $("#tag-input").val(null);
                } else {

                    if ($("#msg").length == 0) {
                        $('.errors').append('<div id="msg">Tag with this name already exsists!</div>');
                    }
                }
            } else {
                if ($("#msg").length == 0) {
                    $('.errors').append('<div id="msg">You cannot add more than 5 tags</div>');
                }
            }
        }
    }
});


$(document).click(function (event) {
    if ($(event.target).attr("class") == 'badge badge-warning') {
        let content = $("#tags").val().split(",");
        for (let i = 0; i < content.length; i++) {
            if ($(event.target).text() == content[i]) {
                $("#msg").remove();
                content.splice(i, 1);
                content.join(",");
                $("#tags").val(content);
                $(event.target).remove();
            }
        }

    }
});