var productlisting = {
    init: function () {

        //bij aanpassen maat of kleur naar de pagina gaan van de maat of kleur
        $("#size, #color").change(function () {
            document.location.href = $(this).find("option:selected").val();
        });

        $(".endShopping").click(function () {
            document.location = $(".topBoxWmHeader").attr("href");
        });

        // Youtube iFrame transparent
        $('iframe').each(function () {
            var url = $(this).attr("src");
            $(this).attr("src", url + (url.indexOf("?") != -1 ? "&" : "?") + "wmode=transparent")
        });

        $(".chatButton").click(function () {
            $(this).find("a").triggerHandler("click");
            return false;
        });

        $(".shopMore").click(function () {
            $.fancybox.close();
        });

        if ($("#mainContent").data("currentname")) {
            var dataGroup = $("#mainContent").data("currentname");
            var dataDivision = $("#mainContent").data("division");
            $("#leftMenu").find("li[data-group='" + dataGroup + "'][data-division='" + dataDivision + "']").addClass("active").parent().addClass("keepOpen");
        }

        $(".subContent").nextAll(".subContent").hide();
        $("#contentNav a").click(function (e) {
            e.preventDefault();

            // Select content
            var rel = $(this).attr("rel");
            $("div[rel='" + rel + "']").show().siblings(".subContent").hide();

            // Select tab
            $("#contentNav a").removeClass("active");
            $(this).addClass("active");
        });

        $("#specsList").find(".slRow:odd").addClass("slRowEven").removeClass("slRow");


        if ($(".scroller .subContent").length > 0) {
            var nrOfImages = $(".scroller .subContent a").length

            /* Scroller uitschakelen bij minder dan 4 afbeeldingen */
            if (nrOfImages <= 3) {
                $(".scrollerRight").addClass("disabled");
            }
            // Breedte scrollerpaneel zetten
            $(".scroller .subContent").css("width", $(".scroller .subContent a").outerWidth(true) * nrOfImages);

            //Scrollerpaneel toevoegen
            if ($.fn.jSlider) {
                $(".scroller .subContent").jSlider({
                    loop: false,
                    btn1: ".scrollerRight",
                    btn2: ".scrollerLeft",
                    visible: 3,

                    beforeShow: function (oldIndex, newIndex, oldElem, newElem) {
                        /* Eerste item pijl naar links uitschakelen */
                        if (newIndex === 0) {
                            $(".scrollerLeft").addClass("disabled");
                            $(".scrollerRight").removeClass("disabled");
                        }
                        else {
                            /* Laatste item, pijl naar rechts uitschakelen */
                            if (newIndex === ($(".scroller .subContent a").length - 3)) {
                                $(".scrollerRight").addClass("disabled");
                                $(".scrollerLeft").removeClass("disabled");
                            }
                            else {
                                $(".scrollerLeft").removeClass("disabled");
                                $(".scrollerRight").removeClass("disabled");
                            }
                        }
                    }
                });
            }
        }

        //track the click on the PDF download button
        $("a.piButton").click(function () {
            if (typeof _gaq != 'undefined') {
                _gaq.push(["_trackEvent", "Productdetail", "PDF Download", $("h1.pageTitle").html()]);
            }
        });
    }
}

jQuery(document).ready(function($) {
    // Afbeelding scroller centreren nadat document ready is
    $(".scroller img").each(function() {
        // Bij liggende afbeelding, maximale hoogte instellen op parent hoogte en horizontaal centreren
        if ($(this).height() != 0 && $(this).width() != 0) {
            if ($(this).height() < $(this).width()) {
                $(this).css("max-height", $(this).parent().height());
                $(this).css("margin-left", 0-($(this).width()-$(this).parent().width())/2);
            }
            // Bij staande afbeelding, maximale breedte instellen op parent breedte en vertikaal centreren
            else {
                $(this).css("max-width", $(this).parent().width());
                $(this).css("margin-top", 0-($(this).height()-$(this).parent().height())/2);
            }
        }
    });
});

$(function() {
    productlisting.init();
    masterpage.initMenu();
    productlisting.initAddProduct();
	
    // Is this a version of IE?
    if ($.browser.msie) {
        $('body').addClass('browserIE');

        // Add the version number
        $('body').addClass('browserIE' + $.browser.version.substring(0, 1));
    }

    $(".prodExtra").each(function() {
        if ($(this).find(".prodExtraSlider").find(".prodExtraItem").length <= 5) {
            $(this).find(".scrollLeft, .scrollRight").remove();
        }
    });

    $(".scrollLeft, .scrollRight").click(slide);
});

function slide()
{
    var container;
    var itemWidth = 150;
    var right;
    var left;
    var move = 0;
    var offset = 0;
    var hiddenLeftSide = 0;
    var visibleItems = 5;
    var totalItems = 0;
    
    if($(this).attr("class").toLowerCase().indexOf("right") != -1)
    {
        container = $(this).prev();
        right = true;
        left = false;
        move = itemWidth;
    }
    else
    {
        container = $(this).next();
        right = false;
        left = true;
        move = -itemWidth;
    }    
    
    offset = container.scrollLeft();
    hiddenLeftSide = Math.floor(offset / itemWidth);
    totalItems = container.children().children().length;
    
    if( left && hiddenLeftSide == 1 )
    {
        $(this).removeClass("active");
    }
    
    if( left )
    {
        $(this).next().next().addClass("active");
    }
    
    if(right && ((visibleItems + hiddenLeftSide) + 1 == totalItems))
    {
        $(this).removeClass("active");
    }
    if( right )
    {
        $(this).prev().prev().addClass("active");
    }
    
    if( container.data("moving") === true)
        return false;
        
    if( (((visibleItems + hiddenLeftSide) < totalItems) && right)
        || ((offset + move) >= 0 && left)
    )
    {
        container.data("moving", true);
        container.animate({scrollLeft : offset + move}, 500, function(){
            container.data("moving", false);
        });
    }
}

