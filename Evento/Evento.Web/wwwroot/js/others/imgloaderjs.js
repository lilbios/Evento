function imgprev(input) {
    if (input.files[0]) {
        var uploading = new FileReader();
        var imgType = input.files[0].type;
        if (imgType == "image/png" || imgType == "image/jpeg"  || imgType == "image/bmp") {
            uploading.onload = function (displayImg) {
                $(".img").attr("src", displayImg.target.result)
            }
            uploading.readAsDataURL(input.files[0]);
        } else {
            $(".error-msg").append("We support only BMP, JPG AND PNG format");
        }
    }
}

function snapshoot(input) {
    let uploadedPhotos = input.files;
    let fileReader = new FileReader();
    if (uploadedPhotos.length > 0) {
        let photos = JSON.parse(window.localStorage.getItem('gallery'));
        for (let i = 0; i < uploadedPhotos.length; i++) {
            if (photos.length == 10) {
                break;
            }
            photos.push(uploadedPhotos[i]);
        }

        fileReader.onload = function (image) {
            $('#upload-photo').attr("src", image.target.result);
        }
        fileReader.readAsDataURL(uploadedPhotos[uploadedPhotos.length - 1]);
        window.localStorage.setItem('pointer', JSON.stringify(uploadedPhotos.length - 1));
        $("#profile-image")
    } 
}