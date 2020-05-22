//function snapshoot(input) {
//    let uploadedPhotos = input.files;
//    let fileReader = new FileReader();
//    if (uploadedPhotos.length <= 10) {
//        fileReader.onload = function (image) {
//            $('#upload-photo').attr("src", image.target.result);
//        }
//        fileReader.readAsDataURL(uploadedPhotos[uploadedPhotos.length - 1]);
//        window.localStorage.setItem('pointer', JSON.stringify(uploadedPhotos.length - 1));
//        $("#profile-image")
//    } else {
//        $('.error-msg').append('You can upload only 10 photos');
//    }
//}
function imgprev(input) {
    if (input.files[0]) {
        var uploading = new FileReader();
        var imgType = input.files[0].type;
        if (imgType == "image/png" || imgType == "image/jpeg" || imgType == "image/bmp") {
            uploading.onload = function (displayImg) {
                $(".img").attr("src", displayImg.target.result)
            }
            uploading.readAsDataURL(input.files[0])
        } else {
            $(".error-msg").append("We support only BMP, JPG AND PNG format");
        }
    }
}

function snapshoot(input) {
    if (input.files.length > 0) {
    }
}