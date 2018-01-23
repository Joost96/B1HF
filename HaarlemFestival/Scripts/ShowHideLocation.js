// verbergt alle informatie van de locaties
function HideAll() {
    $("*[class^='HistoricRouteInfo']").each(function () {
        $(this).hide();
    });
}

// laat de informatie zien van de locatie waar de gebruiker met zijn muis over een drop marker heen gaat
$(".showhide").mouseover(function () {
    var id = $(this).attr("id").substring(3);
    var infor = $(".HistoricRouteInfo" + id);
    if (!infor.is(":visible")) {
        HideAll();
        infor.show();
    }
});