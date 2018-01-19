var modal = document.getElementById('myModal');

$(".TalkingButtonSpreker").click(function () {
    var id = $(this).attr("id");
    var title = $("#spreker1" + id).text();
  

    
    console.log(title);
      
    $(".modaltitle").text(title);
    $("#hahaha").attr("value", title);
   
    $("#myModal").show();
       
});

$(".TalkingButtonSpreker2").click(function () {
    var id = $(this).attr("id");
    var title = $("#spreker2" + id).text();


    
    console.log(title);

    $(".modaltitle").text(title);
    $("#hahaha").attr("value", title);

    $("#myModal").show();

});



$(".close").click(function () {
    modal.style.display = "none";
});

$(window).click(function(event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
});



