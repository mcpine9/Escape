//$(function(){
//	$("#leftMenu ul li ul").hide().first().show();
//	$("#leftMenu > ul > li > a").click(function(){
//		$(this).parent().find("ul").slideDown();
//		$(this).parent().siblings().find("ul").slideUp()
//	});
//});

var masterpage = {
    init: function () {
        var curBranche = $("#mainContent").data("curbranche");

        // Cookie melding
        if ($("div.cookie-opt-in").length) {
            this.cookie.init();
        }

        $(".fcChat").click(function () {
            if (!$(this).hasClass("US")) {
                $(this).find("a").triggerHandler("click");
            }
            return false;
        });

        $(".fcChat.US").attr("onclick", '');

        $("#mainNav").find("a").each(function () {
            if ($(this).data("curbrance") == curBranche) {
                //$(this).addClass("active")
            }
        });

        $(".dynamicForm textarea").parent().addClass("textArea").removeClass("fdInput");

        //$("#mainNav > .navItem:last").addClass("last");

        $("#search").find("input").unbind("keyup");
        $("#search").find("input").keyup(function (e) {
            if ($(this).val().length >= 3) {
                if (e.which === 13) {
                    $("#search").find(".searchButton").click();
                }
            }
            e.preventDefault();
        });

        $("#phone").find("input").keyup(function (e) {
            if ($(this).val().length >= 3) {
                if (e.which === 13) {

                    $("#phone").find(".searchButton").click();
                }
            }
            e.preventDefault();
        });


        $("#phone").find(".searchButton").click(function () {
            callCallMeBack();
            return false;
        });

        $(".fcPhone").click(function () {
            callCallMeBack();
            return false;
        });

        $("#search").find(".searchButton").click(function () {
            if ($(this).parent().find("input").val().length >= 3) {
                $.fancybox.showActivity();
                document.location = $(this).data("baselink") + $(this).parent().find("input").val() + ".aspx"
            }
        });

        $(".popUpBtn").click(function () {
            var params = '';
            var obj = $(this);
            $("#callMeBack").find("input, select").each(function () {
                if (params != '') { params += '|' }
                params += $(this).attr("name") + ":" + $(this).val()
            });
            params += "|language:" + $("#container").data("language");
            if ($("#aspnetForm").valid()) {
                if (!$(obj).hasClass("US")) {
                    _gaq.push(['_trackEvent', 'Contact', 'bel-mij-terug']);
                }
                $.ajax({
                    url: '/json.aspx/callBack',
                    type: 'POST',
                    data: '{ "params": "' + params + '"}',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    success: function (response) {
                        var data = (typeof response.d) === 'string' ? eval('(' + response.d + ')') : response.d;

                        $(".popEnter").hide();
                        $(".popResult").html(data.html);
                        $(".popResult").show();

                    }
                });
            }
        });

        //Calc pagetitle height
        if ($(".pageTitle").clone().appendTo("body").addClass("tempPageTitle").height() > 42) {
            $(".pageTitle").addClass("multipleLine");
        }
        $(".pageTitle.tempPageTitle").remove();
    },
    initMenu: function () {
        $(".mainLeftMenu").click(function (e) {
            e.preventDefault();
        });

        if ($("#mainContent").data("curbranche") === "alle-producten" || $("#mainContent").data("curbranche") === "all-products" || $("#mainContent").data("curbranche") === "alle-produkte") {
            $("#leftMenu").addClass("all-open");
            $(".subLeftMenu").parent().addClass("open").find(".subLeftMenu").slideDown();
        }
        else {
            $(".subLeftMenu:not(.keepOpen)").hide();
            $(".keepOpen").show();
            $(".keepOpen").parent().addClass("open");
            $(".mainLeftMenu").unbind("click");

            $(".mainLeftMenu").click(function () {
                if (!$(this).parent().find(".subLeftMenu").is(":visible")) {
                    $(".subLeftMenu").not(".keepOpen").slideUp();
                    $(".subLeftMenu").parent().removeClass("open");

                    $(this).parent().addClass("open").find(".subLeftMenu").slideDown();
                } else {
                    //als er op een keep open wordt geklikt dan de overige sluiten
                    $(".subLeftMenu").not(".keepOpen").slideUp();
                    $(".subLeftMenu").not(".keepOpen").parent().removeClass("open");
                }
                return false;
            });

            if ($(".subLeftMenu:visible").length == 0) {
                $(".mainLeftMenu:first").click();
            }
        }
    },

    initValidation: function () {
        $(".sendForm").click(function () {
            $("[data-placeholder]").val("");
            if ($("#aspnetForm").valid()) {
                $("#aspnetForm").submit();
            }
        });

        if ($("input:radio").length != 0) {
            $("input:radio").transformRadio({
                checked: "/img/form/radio_checked.png",
                unchecked: "/img/form/radio_unchecked.png"
            })
        }
        if ($("select").length != 0) {
            $("select").each(function () {
                if ($(this).hasClass("showNoFirst")) {
                    $("select").transformSelect({
                        showFirstItemInDrop: false
                    })
                } else {
                    $("select").transformSelect()
                }
            })
        }

        //telefoon nummer validatie
        $.validator.addMethod("phone", function (ph, element) {
            if (ph == null) {
                return false;
            }
            if (ph != "") {
                var stripped = ph.replace(/[\s()\\+-]\.?/gi, "");
                return ((/\d{10,}/i).test(stripped));
            } else {
                return true;
            }
        }, "");

        //er voor zorgen dat er geen meldingen komen op de melding onder in het formulier na
        $.extend($.validator.messages, {
            required: $("#formError").data("required"),
            email: $("#formError").data("email"),
            phone: $("#formError").data("phone")
        });
        $("#aspnetForm").validate({ ignore: ".ignore" });
    },
    cookie: {
        init: function () {
            $("div.cookie-opt-in a.button").one("click", function (e) {
                $("div.cookie-opt-in").remove();
                JL.ajax.post({
                    url: "/json.aspx/ConfirmCookieMessage"
                });
                e.preventDefault();
            });
        }
    }
}

$(function () {
    masterpage.init();
    masterpage.initValidation();

    $("[data-placeholder]").each(function () {
        $(this)
            .placeholder()
            .data("value", $(this).data("placeholder"))
            .blur();

    });
});

function callCallMeBack() {
    var value = $("#phone").find("input").val();

    $("#callMeBack").find("#jclc_Phonenumber1").val(value);

    $(".popEnter").show();
    $(".popResult").hide();

    $.fancybox({
        href: "#callMeBack",
        transitionIn: "none",
        transitionOut: "none",
        centerOnScroll: true,
        onComplete: function() {
            $("input, select").each(function() {
                if ($(this).closest("#fancybox-content").length == 0) {
                    $(this).addClass("ignore");
                }
            });
            $("form").eq(0).append($("#fancybox-wrap"));
            $("#fancybox-content").addClass("has-overflow").children().addClass("holder");
        },
        onClosed: function() {
            $(".ignore").removeClass("ignore");
        }

    });
    return false;
}