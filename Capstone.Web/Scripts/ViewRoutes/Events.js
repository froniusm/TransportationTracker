/// <reference path="../jquery-3.1.1.js" />

$(document).ready(function () {

    var privateRouteSelector = $(".private-route");
    var publicRouteSelector = $(".public-route");
    var tables = $(".waypoint-times-table");

    privateRouteSelector.on("click", function (event) {

        var tdText = $(this).html();
        tdText = tdText.trim();

        for (var i = 0; i < tables.length; i++) {
            tables[i].setAttribute("class", "hidden waypoint-times-table table-responsive table table-hover");
        }
        for (var i = 0; i < tables.length; i++) {
            var tableName = tables[i].getAttribute("id");

            if (tdText == tableName) {
                tables[i].setAttribute("class", "active waypoint-times-table table-responsive table table-hover");
            }
        }
    });

    publicRouteSelector.on("click", function (event) {

        var tdText = $(this).html();
        tdText = tdText.trim();

        for (var i = 0; i < tables.length; i++) {
            tables[i].setAttribute("class", "hidden waypoint-times-table table-responsive table table-hover");
        }
        for (var i = 0; i < tables.length; i++) {
            var tableName = tables[i].getAttribute("id");

            if (tdText == tableName) {
                tables[i].setAttribute("class", "active waypoint-times-table table-responsive table table-hover");
            }
        }
    });

});