// Get the modal
var modal = document.getElementById('myModalHistoric');

// Get the button that opens the modal
var btn = document.getElementById("HistoricButtonOrder1");
var btn2 = document.getElementById("HistoricButtonOrder2");
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("closeHistoric")[0];

// get all options within the form
var day1 = document.getElementById("HistoricDayOption1");
var day2 = document.getElementById("HistoricDayOption2");
var day3 = document.getElementById("HistoricDayOption3");
var time1 = document.getElementById("HistoricTimeOption1");
var time2 = document.getElementById("HistoricTimeOption2");
var time3 = document.getElementById("HistoricTimeOption3");
var lang1 = document.getElementById("HistoricLangOption1");
var lang2 = document.getElementById("HistoricLangOption2");
var lang3 = document.getElementById("HistoricLangOption3");
var amountticket = document.getElementById("numberTicketsHistoric");
var groupticket = document.getElementById("HistoricGroupTicketOption");

// When the user clicks on the button, open the modal 
btn.onclick = function () {
    modal.style.display = "block";
};

btn2.onclick = function () {
    modal.style.display = "block";
};

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
};

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
};


/* --------------- CHINESE FILTERING ------------------- */

// Filter when a day is selected
day1.onclick = function () {
    $('#HistoricLangOption3').attr('disabled', true);
    if ($('#HistoricLangOption3').is(":checked")) {
        $('#HistoricLangOption3').prop('checked', false);
    }
};


day2.onclick = function () {
    if ($('#HistoricTimeOption1').is(":checked") || $('#HistoricTimeOption3').is(":checked")) {
        $('#HistoricLangOption3').prop('checked', false);
        $('#HistoricLangOption3').attr('disabled', true);
    } else {
        $('#HistoricLangOption3').attr('disabled', false);
    }
};

day3.onclick = function () {
    if ($('#HistoricTimeOption1').is(":checked")) {
        $('#HistoricLangOption3').prop('checked', false);
        $('#HistoricLangOption3').attr('disabled', true);
    } else {
        $('#HistoricLangOption3').attr('disabled', false);
    }
};


// Filter when a time is selected
time1.onclick = function () {
    $('#HistoricLangOption3').attr('disabled', true);
    if ($('#HistoricLangOption3').is(":checked")) {
        $('#HistoricLangOption3').prop('checked', false);
    }
};

time2.onclick = function () {
    if ($('#HistoricDayOption1').is(":checked")) {
        $('#HistoricLangOption3').prop('checked', false);
        $('#HistoricLangOption3').attr('disabled', true);
    } else {
        $('#HistoricLangOption3').attr('disabled', false);
    }
};

time3.onclick = function () {
    if ($('#HistoricDayOption1').is(":checked") || $('#HistoricDayOption2').is(":checked")) {
        $('#HistoricLangOption3').prop('checked', false);
        $('#HistoricLangOption3').attr('disabled', true);
    } else {
        $('#HistoricLangOption3').attr('disabled', false);
    }
};

groupticket.onclick = function () {
    if ($('#HistoricGroupTicketOption').is(":checked")){
        $('#numberTicketsHistoric').val(4);
        $('#numberTicketsHistoric').attr('disabled', true);
    } else {
        $('#numberTicketsHistoric').attr('disabled', false);
    }
};