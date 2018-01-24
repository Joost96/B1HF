

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
var day = document.getElementsByName("day");
var time1 = document.getElementById("HistoricTimeOption1");
var time2 = document.getElementById("HistoricTimeOption2");
var time3 = document.getElementById("HistoricTimeOption3");
var time = document.getElementsByName("time");
var lang1 = document.getElementById("HistoricLangOption1");
var lang2 = document.getElementById("HistoricLangOption2");
var lang3 = document.getElementById("HistoricLangOption3");
var lang = document.getElementsByName("language");
var amountticket = document.getElementById("numberTicketsHistoric");
var groupticket = document.getElementById("HistoricGroupTicketOption");
var submit = document.getElementById("HistoricSubmit");
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

// groupticket selection
groupticket.onclick = function () {
    if ($('#HistoricGroupTicketOption').is(":checked")){
        $('#numberTicketsHistoric').val(4);
        $('#numberTicketsHistoric').attr('disabled', true);
    } else {
        $('#numberTicketsHistoric').attr('disabled', false);
    }
};

submit.onclick = function () {
    var valDay = $('input[name="day"]:checked').val();
    var valTime = $('input[name="time"]:checked').val();
    var valLang = $('input[name="language"]:checked').val();
    var valTickets = $('#numberTicketsHistoric').val();
    var Ticket_TimeSlot_Activity_Id;
    var Ticket_Type;
    var Ticket_TimeSlot_StartTime;
    var Amount;
    var TotalPrice;

    switch (valLang)
    {
        case 1:
            Ticket_TimeSlot_Activity_Id = 43;
            break;
        case 2:
            Ticket_TimeSlot_Activity_Id = 42;
            break;
        case 3:
            Ticket_TimeSlot_Activity_Id = 44;
            break;
    }

    switch (valDay)
    {
        case 1:
            Ticket_TimeSlot_StartTime = "26/07/2018";
            break;
        case 2:
            Ticket_TimeSlot_StartTime = "27/07/2018";
            break;
        case 3:
            Ticket_TimeSlot_StartTime = "28/07/2018";
            break;
    }

    switch (valTime)
    {
        case 1:
            Ticket_TimeSlot_StartTime += " 10:00:00";
            break;
        case 2:
            Ticket_TimeSlot_StartTime += " 13:00:00";
            break;
        case 3:
            Ticket_TimeSlot_StartTime += " 16:00:00";
            break;
    }

    amount = $('numberTicketsHistoric').val();

    if ($('#HistoricGroupTicketOption').is(":checked")) {
        Ticket_Type = 1;
    } else {
        Ticket_Type = 0;
    }

    switch (Ticket_Type)
    {
        case 0:
            TotalPrice = Amount * 17.5;
            break;
        case 1:
            TotalPrice = 60;
            break;
    }


};