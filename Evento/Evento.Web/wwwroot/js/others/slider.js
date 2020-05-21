
function next() {
    let gallery = document.getElementById('photoholder').files;
    let pointer = JSON.parse(window.localStorage.getItem('pointer'));


    if (pointer < gallery.length -1) {
        pointer = pointer + 1;
    } else {
        pointer = 0;
    }

    urlSetter(gallery,pointer);
}
function prev() {
    let gallery = document.getElementById('photoholder').files;
    let pointer = JSON.parse(window.localStorage.getItem('pointer'));

    if (pointer > 0 && pointer < gallery.length) {
        pointer = pointer - 1;
    } else {
        pointer = gallery.length - 1;
    }
    urlSetter(gallery,pointer);
}

function urlSetter(gallery,pointer) {
    let uploading = new FileReader();
    uploading.onload = function (displayImg) {
        $("#upload-photo").attr("src", displayImg.target.result)
    }
    uploading.readAsDataURL(gallery[pointer]);
    window.localStorage.setItem('pointer', JSON.stringify(pointer));
}