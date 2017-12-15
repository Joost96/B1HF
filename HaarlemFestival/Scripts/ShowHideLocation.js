var info = document.getElementsByClassName("HistoricRouteInfo");
var dropMarkerGuide = document.getElementsByClassName("HistoricImageDropMarker10");
var info1 = document.getElementsByClassName("HistoricRouteInfo1");
var info2 = document.getElementsByClassName("HistoricRouteInfo2");
var info3 = document.getElementsByClassName("HistoricRouteInfo3");
var info4 = document.getElementsByClassName("HistoricRouteInfo4");
var info5 = document.getElementsByClassName("HistoricRouteInfo5");
var info6 = document.getElementsByClassName("HistoricRouteInfo6");
var info7 = document.getElementsByClassName("HistoricRouteInfo7");
var info8 = document.getElementsByClassName("HistoricRouteInfo8");
var info9 = document.getElementsByClassName("HistoricRouteInfo9");

function ShowHideLocation() {
    if (info1.style.class === "none") {
        info1.style.display = "block";
        info.style.display = "none";
        //info2.style.display = "none";
        //info3.style.display = "none";
        //info4.style.display = "none";
        //info5.style.display = "none";
        //info6.style.display = "none";
        //info7.style.display = "none";
        //info8.style.display = "none";
        //info9.style.display = "none";
    } else {
        info1.style.display = "none";
    }
}