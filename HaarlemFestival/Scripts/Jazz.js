var modal = document.getElementById('myModal');

$(".jazz_page_buybtn").click(function () {
    var id = $(this).attr("id");
    var title = $("#jazz_activity_title_" + id).text();
    var location = $("#jazz_activity_location_" + id).text();
    var hall = $("#jazz_activity_hall_" + id).text();
    var price = $("#jazz_activity_price_" + id).text();
    var time = $("#jazz_activity_time_" + id).text();
    var datum = $("#jazz_activity_datum_" + id).text();

    $(".modaltitle").text(title);
    $(".modallocation").text(location);
    $(".modalhall").text(hall);
    $(".modalprice").text(price);
    $(".modaltime").text(time);
    $(".modaldatum").text(datum);

    $("#myModal_" + id).show();

    $("#link").click(function (event) {
        $("#myModal_" + id).hide();

        $("ValidatingBtn").click(function () {
            


        });
        $("CancelBtn").click(function () {
            $("#myModal_" + id).show();


        });



        var actionlinkUrl = $("#link").prop("href");

        var url = actionlinkUrl.replace("xxxx", $("#textBox_" + id).val());
        $("#link").prop("href", url);
    });
});


$(".close").click(function () {
    $(".modal").each(function () {
        $(this).hide();
    });
});

$(window).click(function(event) {
    if (event.target.className == "modal") {
        $(".modal").each(function () {
            $(this).hide();
        });
    }
});



