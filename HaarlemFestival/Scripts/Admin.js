console.log("loaded");
$('main img').click(function () {
    var id = $(this).attr("id");
    $(".imgUpload#" + id).click();
    console.log("here");
});

$("main .imgUpload").change(function () {
    var file = event.target.files[0];
    var id = $(this).attr("id")
    // Ensure it's an image
    if (file.type.match(/image.*/)) {
        console.log('An image has been loaded');

        // Load the image
        var reader = new FileReader();
        reader.onload = function (readerEvent) {
            var image = new Image();
            image.onload = function (imageEvent) {

                // Resize the image
                var canvas = document.createElement('canvas');
                var width = image.width;
                var height = image.height;
                if (width / 277 < height / 300) {
                    height = width / 277 * 300;
                } else {
                    width = height / 300 * 277;
                }
                canvas.width = width;
                canvas.height = height;
                canvas.getContext('2d').drawImage(image, 0, 0, width, height, 0, 0, width, height);
                var dataUrl = canvas.toDataURL('image/jpeg');
                $('img#' + id).attr('src', dataUrl);
                $('input[type=hidden]#' + id).attr('value', dataUrl);
            }
            image.src = readerEvent.target.result;
        }
        reader.readAsDataURL(file);
    }
});