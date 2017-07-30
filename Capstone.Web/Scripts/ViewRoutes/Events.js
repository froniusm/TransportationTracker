<reference path="../jquery-3.1.1.js" />

$(document).ready(function () {

    var privateRouteSelector = $(".private-route");
    var publicRouteSelector = $(".public-route");
    var tables = $(".waypoint-times-table");
    var TEST = $("#TEST");

    TEST.on("click", function (event) {
        consol.log("test works");
    });

    privateRouteSelector.on("click", function (event) {
        console.log("buttons work");
        for (var i = 0; i < tables.length; i++) {

            console.log("buttons work");

            if (this.privateRouteSelector.value == $(this.tables).attr('id')) {
                $(this.tables).removeClass("hidden");
                $(this.tables).toggleClass("active");
            };
        }
    });

    publicRouteSelector.on("click", function (event) {
        console.log("buttons work");
        if (isChecked) {
            for (var i = 0; i < billingAddress.length; i++) {
                shippingAddress[i + 1].value = billingAddress[i].value;
            }
            console.log("ShippingSameButtonWorks");
        }
    });

});