/// <reference path="../lib/jquery/jquery-2.1.0.js" />
$(function() {
    $("*[data-clickable]").click(function() {
        window.location.href = $(this).data("clickable");
    })
    .css("cursor", "pointer");
});