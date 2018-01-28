var modal = document.getElementById('QuestionModal');
var bedankModel = document.getElementById('ThanksModal');
var waited = false;

$(".TalkingButtonSpreker").click(function () {
    var id = $(this).attr("id");
    var title = $("#spreker1" + id).text();
  
    
   
      
    $(".modaltitle").text(title);
    $("#sprekerNaam").attr("value", title);
   
    $("#QuestionModal").show();
       
});

$(".TalkingButtonSpreker2").click(function () {
    var id = $(this).attr("id");
    var title = $("#spreker2" + id).text();


    $(".modaltitle").text(title);
    $("#sprekerNaam").attr("value", title);

    $("#QuestionModal").show();

});

$(".TalkingButtonBook").click(function () {
    var id = $(this).attr("id");
    var title = $("#" + id).text();

    $(".OrderTitle").text(title);
    $("#AvtivityId").attr("value", id);

    $("#OrderModal").show();

});



$(".close").click(function () {

    modal.style.display = "none";
});

$("#closeThanksModal").click(function () {

    $("#ThanksModal").hide();
});

$("#closeOrderModal").click(function () {

    $("#OrderModal").hide();
});



$(window).click(function(event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
});



$("#TalkingQuestionForm").submit(function () {

    $("#ThanksModal").show();
    $("#QuestionModal").hide();
    
    setTimeout(function () {
        
        waited = true;
        $("#TalkingQuestionForm").submit();

    }, 3000);
    return waited;
});

$("#TalkingOrderForm").submit(function () {

    $("#ThankYouOrderMessage").show();
    $("#OrderMessage").hide();
    $("#OrderSelect").hide();
    $("#TalkingOrderButton").hide();

    setTimeout(function () {

        waited = true;
        $("#TalkingOrderForm").submit();

    }, 3000);
    return waited;
});



var password = document.getElementById("PasswordBox") , confirm_password = document.getElementById("ConfirmPasswordBox");

function validatePassword() {
    if (password.value != confirm_password.value) {
        confirm_password.setCustomValidity("Passwords Don't Match");
    } else {
        confirm_password.setCustomValidity('');
    }
}

password.onchange = validatePassword;
confirm_password.onkeyup = validatePassword;





