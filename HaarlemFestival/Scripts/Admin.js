$('.datepicker').datetimepicker({
    formatTime: 'H:i',
    format: 'd-m-Y H:i',
    //mask: true,
    allowTimes: [
        '10:00', '10:30', '11:00', '11:30', '12:00',
        '12:30', '13:00', '13:30', '14:00', '14:30',
        '15:00', '15:30', '16:00', '16:30', '17:00',
        '17:30', '18:00', '18:30', '19:00', '19:30',
        '20:00', '20:30', '21:00', '21:30', '22:00',
        '22:30', '23:00'
    ],
    timepickerScrollbar: false
});
//drag and drop
var dragStart = null;

$(".HomeHighlight").on("dragstart", function (e) {
    $(this).addClass("dragged");
    dragStart = this;

    e.originalEvent.dataTransfer.effectAllowed = 'move';
    e.originalEvent.target.style.opacity = 1;
    e.originalEvent.dataTransfer.setData('text/html', this.innerHTML);
});
$(".HomeHighlight").on("dragover", function (e) {
    $(this).addClass("dragOver");
});
$(".HomeHighlight").on("dragleave", function (e) {
    $(this).removeClass("dragOver");
});
$(".HomeHighlight").on("dragover", function (e) {
    e.preventDefault();
    e.originalEvent.dataTransfer.dropEffect = 'move';
});
$(".HomeHighlight").on("drop", function (e) {
    console.log("drop");
    if (e.stopPropagation) {
        e.stopPropagation();
    }

    if (dragStart !== this) {
        dragStart.innerHTML = this.innerHTML;
        this.innerHTML = e.originalEvent.dataTransfer.getData('text/html');

        var section = $(dragStart).find("input[id*='Section']").attr("value");
        $(dragStart).find("input[id*='Section']").attr("value", $(this).find("input[id*='Section']").attr("value"));
        $(this).find("input[id*='Section']").attr("value", section);
    }
    return false;
});
$(".HomeHighlight").on("dragend", function () {
    $(this).removeClass("dragged");
    $(".dragover").each(function () {
        $(this).removeClass("dragover");
    });
});

//image
$('main img').click(function () {
    var id = $(this).attr("id");
    $(".imgUpload#" + id).click();
    console.log("here");
});

$("main .imgUpload").change(function () {
    var file = event.target.files[0];
    var id = $(this).attr("id");
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
            };
            image.src = readerEvent.target.result;
        };
        reader.readAsDataURL(file);
    }
});