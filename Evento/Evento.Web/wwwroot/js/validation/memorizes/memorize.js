function validation() {
    let input = document.getElementsByClassName("loader");
    let photosAmount = input.files.length;
    let token = true;

    if ($('.mem-title').val() == '') {
        token = false;
    }
    if (photosAmount == 0) {
        token = false;
    }
    return false;

}