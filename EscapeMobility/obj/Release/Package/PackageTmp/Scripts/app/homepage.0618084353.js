$(function() {
    $(".latestNewsItem").last().addClass("last");

    var length = $("#liveboardContent li").length;
    for (var i = 0; i < length; i++) {
        $("#liveboardNav ul").prepend("<li>" + (length - i) + "</li>");
    }
    $("#liveboardNav").width($("#liveboardNav li").length * 30);

    // Geen tekst verwijder
    $(".descHolder").each(function() {
        if ($.trim($(this).text()) == "") {
            $(this).closest(".popupSlider").css("padding", "0");
        }
    });
    // Init liveboard
    $("body").liveboard({
        liveboardID: "#liveboard",
        contentUL: "#liveboardContent",
        menuUL: "#liveboardNav",
        useInterval: true,
        contentSlideText: ".popupSlider",
        intervalTime: 8000
    });

    //$("#twitter_update_list").jtwt({ username: $("#twitter_update_list").data("name"), count: 10, image_size : false });

    $("#liveboardNav .prev").click(function() {
        var index = $(this).parent().find(".selected").index();
        index--;
        if (index < 0) {
            index = $(this).parent().find(".liveboard-item:not([exclude])").length - 1;
        }
        $(this).parent().find("li").eq(index).click();
    });

    $("#liveboardNav .next").click(function() {
        var index = $(this).parent().find(".selected").index();
        index++;
        if (index > $(this).parent().find(".liveboard-item:not([exclude])").length - 1) {
            index = 0;
        }
        $(this).parent().find("li").eq(index).click();
    });

    $("#liveboardNav .pause").click(function() {
        $(this).toggleClass("ps");
        if ($(this).hasClass("ps")) {
            clearTimeout($("#liveboard").data("interval"));
        }
        else {
            $("#liveboardNav .next").click();
        }
    });


    //$("#liveboardContent").find("img").each(function() {
    //    if ($(this).attr("src") == '/img/content/loader.gif') {
    //        $(this).removeClass("loading");
    //        $(this).attr("src", $(this).attr("data-loadsrc"));
    //    };
    //});
});