var waited = false;
$(".Admin-Form").submit(function () {

    $("#Save-Modal").show();
    if (!waited) {
        setTimeout(function () {

            waited = true;
            $(".Admin-Form").submit();

        }, 1000);
    }
    return waited;
});

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

var imgWidth;
var imgHeight;
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
                if (width / imgWidth < height / imgHeight) {
                    height = width / imgWidth * imgHeight;
                } else {
                    width = height / imgHeight * imgWidth;
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

//jazz agenda
var schedule;

var timeline;
var timelineStart;
var timelineSlotDuration;

var eventsWrapper;
var eventsGroup;
var singleEvents;
var eventSlotHeight;
var eventSlotWidth;

function SchedulePlan(element) {
    schedule = element;
    timeline = schedule.find('.timeline');
    var timelineItems = schedule.find('li');
    var timelineItemsNumber = timelineItems.length;
    timelineStart = getScheduleTimestamp(timelineItems.eq(0).text());
    //need to store delta (in our case half hour) timestamp
    timelineSlotDuration = getScheduleTimestamp(timelineItems.eq(1).text()) - getScheduleTimestamp(timelineItems.eq(0).text());

    eventsWrapper = schedule.find('.events');
    eventsGroup = eventsWrapper.find('.events-group');
    singleEvents = eventsGroup.find('.single-event');
    eventSlotHeight = eventsGroup.eq(0).children('.top-info').outerHeight();
    eventSlotWidth = eventsGroup.eq(0).children('.top-info').outerWidth();

    placeEvents();
}
function placeEvents() {
    singleEvents.each(function () {
        //place each event in the grid
        var start = getScheduleTimestamp($(this).attr('data-start')),
            duration = getScheduleTimestamp($(this).attr('data-end')) - start;
        var eventTop = eventSlotHeight * (start - timelineStart) / timelineSlotDuration;
        var eventHeight = eventSlotHeight * duration / timelineSlotDuration;
        var sameTime = $(this).parent().find("[data-start='" + $(this).attr('data-start') + "']");
        var index;
        for (var i = 0; i < sameTime.length; i++) {
            if (sameTime[i] === $(this)[0]) {
                index = i;
            }
        }
        var eventLeft = eventSlotWidth / sameTime.length * index;
        $(this).css({
            width: 100 / sameTime.length + '%',
            left: eventLeft+index + 'px',
            top: eventTop - 1 + 'px',
            height: eventHeight + 1 + 'px'
            
        });
        
    }); 
}

function getScheduleTimestamp(time) {
    //accepts hh:mm format - convert hh:mm to timestamp
    time = time.replace(/ /g, '');
    var timeArray = time.split(':');
    var timeStamp = parseInt(timeArray[0]) * 60 + parseInt(timeArray[1]);
    return timeStamp;
}

$(window).bind('hashchange', function () {
    var hash = window.location.hash.replace(/^#/, '');
    console.log(hash);

    $(".single-event").removeClass("selected");
    $("li[id ^='cal-" + hash + "']").addClass("selected");

    $(".jazz-edit").hide();
    $("#edit-" + hash).show();
});

//--
$(document).ready(function () {
    if (window.location.hash) {
        var hash = window.location.hash;
        window.location.hash = 0;
        window.location.hash = hash;
    } else {
        window.location.hash = "#6";
    }
    //$(window).trigger("hashchange");
    SchedulePlan($(".schedule"));
    var main = $("main");
    if (main.hasClass("HomePage")) {
        imgHeight = 300;
        imgWidth = 277;
    } else if (main.hasClass("Jazz")) {
        imgHeight = 280;
        imgWidth = 320;
    }
});