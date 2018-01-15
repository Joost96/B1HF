// WIP

//var info = document.getElementsByClassName("HistoricRouteInfo");
//var dropMarkerGuide = document.getElementsByClassName("HistoricImageDropMarker10");
//var info1 = document.getElementsByClassName("HistoricRouteInfo1");
//var info2 = document.getElementsByClassName("HistoricRouteInfo2");
//var info3 = document.getElementsByClassName("HistoricRouteInfo3");
//var info4 = document.getElementsByClassName("HistoricRouteInfo4");
//var info5 = document.getElementsByClassName("HistoricRouteInfo5");
//var info6 = document.getElementsByClassName("HistoricRouteInfo6");
//var info7 = document.getElementsByClassName("HistoricRouteInfo7");
//var info8 = document.getElementsByClassName("HistoricRouteInfo8");
//var info9 = document.getElementsByClassName("HistoricRouteInfo9");

//function ShowHideLocation() {
//    if (info1.style.display === "none") {
//        info1.style.display = "block";
//        info.style.display = "none";
//        //info2.style.display = "none";
//        //info3.style.display = "none";
//        //info4.style.display = "none";
//        //info5.style.display = "none";
//        //info6.style.display = "none";
//        //info7.style.display = "none";
//        //info8.style.display = "none";
//        //info9.style.display = "none";
//    } else {
//        info1.style.display = "none";
//    }
//}

var info = $(".HistoricRouteInfo");
var info1 = $(".HistoricRouteInfo1");
var info2 = $(".HistoricRouteInfo2");
var info3 = $(".HistoricRouteInfo3");
var info4 = $(".HistoricRouteInfo4");
var info5 = $(".HistoricRouteInfo5");
var info6 = $(".HistoricRouteInfo6");
var info7 = $(".HistoricRouteInfo7");
var info8 = $(".HistoricRouteInfo8");
var info9 = $(".HistoricRouteInfo9");

function HideAll() {
    info.hide();
    info1.hide();
    info2.hide();
    info3.hide();
    info4.hide();
    info5.hide();
    info6.hide();
    info7.hide();
    info8.hide();
    info9.hide();
}

function ShowHideLocation1() {
    if (!info1.is(":visible"))
    {
        HideAll();
        info1.show();
    }
}
function ShowHideLocation2() {
    if (!info2.is(":visible")) {
        HideAll();
        info2.show();
    }
}
function ShowHideLocation3() {
    if (!info3.is(":visible")) {
        HideAll();
        info3.show();
    }
}
function ShowHideLocation4() {
    if (!info4.is(":visible")) {
        HideAll();
        info4.show();
    }
}
function ShowHideLocation5() {
    if (!info5.is(":visible")) {
        HideAll();
        info5.show();
    }
}
function ShowHideLocation6() {
    if (!info6.is(":visible")) {
        HideAll();
        info6.show();
    }
}
function ShowHideLocation7() {
    if (!info7.is(":visible")) {
        HideAll();
        info7.show();
    }
}
function ShowHideLocation8() {
    if (!info8.is(":visible")) {
        HideAll();
        info8.show();
    }
}
function ShowHideLocation9() {
    if (!info9.is(":visible")) {
        HideAll();
        info9.show();
    }
}