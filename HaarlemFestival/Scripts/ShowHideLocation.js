function HideAll() {
    $("*[class^='HistoricRouteInfo']").each(function () {
        $(this).hide();
    });
}

$(".showhide").mouseover(function () {
    var id = $(this).attr("id").substring(3);
    var infor = $(".HistoricRouteInfo" + id);
    if (!infor.is(":visible")) {
        HideAll();
        infor.show();
    }
});