$(".jazz_page_buybtn").click(function () {
    var id = $(this).attr("id");
    var title = $("#jazz_activity_title_" + id).text();
    var description = $("#jazz_activity_description_" + id).text();
    var location = $("#jazz_activity_location_" + id).text();
    var hall = $("#jazz_activity_hall_" + id).text();
    var price = $("#jazz_activity_price_" + id).text();
    var time = $("#jazz_activity_time_" + id).text();
    var datum = $("#jazz_activity_datum_" + id).text();

    $(".modaltitle").text(title);
    $(".modaldescription").text(description);
    $(".modallocation").text(location);
    $(".modalhall").text(hall);
    $(".modalprice").text(price);
    $(".modaltime").text(time + " on " + datum);

    $("#myModal_" + id).show();

    $("#orderlink_" + id).click(function () {

        $("#myModal_" + id).hide();

        var ordertxt = $(".ordertext").text();

        var actionlinkUrl = $("#orderlink_" + id).prop("href");
        var url = actionlinkUrl.replace("xxxx", $("#textBox_" + id).val());
        $("#orderlink_" + id).prop("href", url);

        setTimeout(function () {
            alert(ordertxt);
        }, 100);
    });
});

$(".close").click(function () {
    $(".modal").each(function () {
        $(this).hide();
    });
});

$(window).click(function(event) {
    if (event.target.className === "modal") {
        $(".modal").each(function () {
            $(this).hide();
        });
    }
});



$(".jazz_page_infobtn").click(function () {
    var id = $(this).attr("id");
    var title = $("#jazz_activity_title_" + id).text();
    var description = $("#jazz_activity_description_" + id).text();

    $(".infomodaltitle").text(title);
    $(".infomodaldescription").text(description);

    $("#infoModal_" + id).show();
});

$(".infomodalclose").click(function () {
    $(".infomodal").each(function () {
        $(this).hide();
    });
});

$(window).click(function (event) {
    if (event.target.className === "infomodal") {
        $(".infomodal").each(function () {
            $(this).hide();
        });
    }
});







var modal1 = document.getElementById('passPartoutModalId');

$(".jazz_page_program_passpartout").click(function () {
    $("#passPartoutModalId").show();

    $("#passpartoutlink1").click(function (event) {
        $("#passPartoutModalId").hide();
        $("#aantalModalId1").show();

    });

    $("#passpartoutlink2").click(function (event) {
        $("#passPartoutModalId").hide();
        $("#aantalModalId2").show();

    });

    $("#passpartoutlink3").click(function (event) {
        $("#passPartoutModalId").hide();
        $("#aantalModalId3").show();

    });

    $("#passpartoutlink4").click(function (event) {
        $("#passPartoutModalId").hide();
        $("#aantalModalId4").show();

    });
});

$(".passPartoutModalClose").click(function () {
    modal1.style.display = "none";
});

$(window).click(function (event) {
    if (event.target.className === "passPartoutModalClass") {
        modal1.style.display = "none";
    }
});









var modal2 = document.getElementById('aantalModalId1');

$("#passpartoutorderlink1").click(function () {
    var actionlinkUrl = $("#passpartoutorderlink1").prop("href");
    var url = actionlinkUrl.replace("xxxx", $("#textboxaantal1").val());
    $("#passpartoutorderlink1").prop("href", url);

    var ordertxt = $(".ordertext").text();
    setTimeout(function () {
        alert(ordertxt);
    }, 100);
});

$(".aantalModalClose1").click(function () {
    modal2.style.display = "none";
});

$(window).click(function (event) {
    if (event.target.className === "aantalModalClass1") {
        modal2.style.display = "none";
    }
});




var modal3 = document.getElementById('aantalModalId2');

$("#passpartoutorderlink2").click(function () {

    var actionlinkUrl = $("#passpartoutorderlink2").prop("href");
    var url = actionlinkUrl.replace("xxxx", $("#textboxaantal2").val());
    $("#passpartoutorderlink2").prop("href", url);

    var ordertxt = $(".ordertext").text();
    setTimeout(function () {
        alert(ordertxt);
    }, 100);
});

$(".aantalModalClose1").click(function () {
    modal3.style.display = "none";
});

$(window).click(function (event) {
    if (event.target.className === "aantalModalClass1") {
        modal3.style.display = "none";
    }
});




var modal4 = document.getElementById('aantalModalId3');

$("#passpartoutorderlink3").click(function () {
    var actionlinkUrl = $("#passpartoutorderlink3").prop("href");
    var url = actionlinkUrl.replace("xxxx", $("#textboxaantal3").val());
    $("#passpartoutorderlink3").prop("href", url);

    var ordertxt = $(".ordertext").text();
    setTimeout(function () {
        alert(ordertxt);
    }, 100);
});

$(".aantalModalClose1").click(function () {
    modal4.style.display = "none";
});

$(window).click(function (event) {
    if (event.target.className === "aantalModalClass1") {
        modal4.style.display = "none";
    }
});




var modal5 = document.getElementById('aantalModalId4');

$("#passpartoutorderlink4").click(function () {
    var actionlinkUrl = $("#passpartoutorderlink4").prop("href");
    var url = actionlinkUrl.replace("xxxx", $("#textboxaantal4").val());
    $("#passpartoutorderlink4").prop("href", url);

    var ordertxt = $(".ordertext").text();
    setTimeout(function () {
        alert(ordertxt);
    }, 100);
});

$(".aantalModalClose1").click(function () {
    modal5.style.display = "none";
});

$(window).click(function (event) {
    if (event.target.className === "aantalModalClass1") {
        modal5.style.display = "none";
    }
});

