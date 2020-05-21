function snapshoot(input) {
    let uploadedPhotos = input.files;
    let fileReader = new FileReader();
    if (uploadedPhotos.length <= 10) {
        fileReader.onload = function (image) {
            $('#upload-photo').attr("src", image.target.result);
        }
        fileReader.readAsDataURL(uploadedPhotos[uploadedPhotos.length - 1]);
        window.localStorage.setItem('pointer', JSON.stringify(uploadedPhotos.length - 1));
        $("#profile-image")
    } else {
        $('.error-msg').append('You can upload only 10 photos');
    }
}