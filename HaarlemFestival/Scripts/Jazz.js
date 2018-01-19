var modal = document.getElementById('myModal');

$(".jazz_page_buybtn").click(function () {
    var id = $(this).attr("id");
    var title = $("#jazz_activity_title_" + id).text();
    var location = $("#jazz_activity_location_" + id).text();
    var hall = $("#jazz_activity_hall_" + id).text();
    var price = $("#jazz_activity_price_" + id).text();
    var time = $("#jazz_activity_time_" + id).text();

    var datum = $("#jazz_activity_datum_" + id).text();
    var prijs = parseFloat($("#jazz_activity_ticket_price_" + id).text());
    

    console.log(id);
    console.log(title);
    console.log(location);
    console.log(hall);
    console.log(time);
    console.log(datum);
    console.log(price);
    console.log(prijs);
    

    $(".modaltitle").text(title);
    $(".modallocation").text(location);
    $(".modalhall").text(hall);
    $(".modalprice").text(price);
    $(".modaltime").text(time);
    $(".modaldatum").text(datum);

    $("#myModal").show();

    var aantal = $('.jazz_order_aantal').val();
    console.log(aantal);

    $(".jjjazz_order_btn").click(function () {
        var aantal = $('.jazz_order_aantal').val();
        console.log(aantal);
    });
});



$(".close").click(function () {
    modal.style.display = "none";
});

$(window).click(function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
});



