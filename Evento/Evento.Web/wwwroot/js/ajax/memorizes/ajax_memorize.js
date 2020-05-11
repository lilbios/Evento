function post() {
    let titile = $("#title").val();
    let memorizeComment = $("#comment").val();
    let input = document.getElementById("photoholder");
    let photos = input.files;

    let formData = new FormData();

    formData.append("Titile", title);
    formData.append("MemorizeComment", memorizeComment);
    for (var i = 0; i != photos.length; i++) {
        formData.append("Snapshoots", photos[i]);
    }

    $.ajax({
        type: "Post",
        url: "/Memorizes/CreateNewMemorize",
        data: formData,
        contentType: false,
        processData:false
        });



}