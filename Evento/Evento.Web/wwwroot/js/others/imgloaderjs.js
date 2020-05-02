function imgprev(input) {
    if (input.files[0]) {
        var uploading = new FileReader();
        var imgType = input.files[0].type;
        if (imgType == "image/png" || imgType == "image/jpeg" || imgType == "image/gif" || imgType == "image/bmp") {
            uploading.onload = function (displayImg) {
                $(".img").attr("src", displayImg.target.result)
            }
            uploading.readAsDataURL(input.files[0])
        } else {

        }
    }
}