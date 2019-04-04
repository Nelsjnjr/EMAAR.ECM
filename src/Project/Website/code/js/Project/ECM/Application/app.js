'use strict';

/* To get JSON DATA  */
var getData = (function ($) {

    var spinner = '<div class="spinner"><div class="lds-ripple"><div></div><div></div></div></div>';

    var _fancyboxImage = function() {
        if ($('.fancyimages').length) {
            $(".fancyimages").fancybox({
                openEffect	: "none",
                closeEffect	: "none",
        
                helpers : {
                    title : {
                        type : 'inside'
                    }
                }
            });
        }
    }
    // To get the Forum tabs data and populate it accordingly
    var _tabs = function (url, tabClass, tabContentClass, pagination) {

        // For loading
        $("#tabs-head-result").html(spinner);

        // To get Data
        $.get(url, function (data) {
            if (data.error == null) {

                var source = $("#tabs-head").html(),
                    template = Handlebars.compile(source),
                    html = template(data.Result);
                $("#tabs-head-result").html(html);


                var source2 = $("#tabs-content").html(),
                    template2 = Handlebars.compile(source2),
                    html2 = template2(data.Result);
                $("#tabs-content-result").html(html2);

                var tabIndex = $(tabClass).find(".active").attr("data-tab-index");
                $(tabContentClass).hide();
                $(tabContentClass).each(function () {
                    if ($(this).attr("data-tab") == tabIndex) {
                        $(this).fadeIn();
                    }
                })

                $(tabClass).find("li").click(function () {
                    if ($(this).hasClass("disbaled")) {
                        return false
                    }
                    $(this).addClass("active").siblings().removeClass("active");
                    var tabIndex = $(this).attr("data-tab-index");
                    $(tabContentClass).hide();
                    $(tabContentClass).each(function () {
                        if ($(this).attr("data-tab") == tabIndex) {
                            $(this).fadeIn();
                        }
                    })
                })


            } else {}
        })
    }
    
    var _results = function (url, pagination, loadmoreID, templateID, resultId) {
        var loadID = loadmoreID ? loadmoreID : ".loadmore",
            tempDiv = templateID ? templateID : "#filter-template",
            galleryTemp = templateID ? templateID : "#gallery-template",
            resultDiv = resultId ? resultId : "#filter-template-result";
        var dataPageSize = $('#templateInitializor').data('page-size');

        $("#filter-template-result").html(spinner);
       
        $.get(url, 
            function (data) {
            if (data.error == null) {
                var source2 = $(galleryTemp).html(),
                template2 = Handlebars.compile(source2);
                if (data.results != null && dataPageSize < data.results.Totalcount) {
                    $(".loadmore").show();
                } else {
                    $(".loadmore").hide();
                }
                $('.spinner').remove();
                for (var j = 0; dataPageSize > j && j < data.results.Totalcount; j++){
                    $(resultDiv).append(template2(data.results.results[j]));
                }
                
                _fancyboxImage();
            } else {}
        });
    }

    var _filter = function (url, pagination, loadmoreID, templateID, resultId) {
        // For loading
        var loadID = loadmoreID ? loadmoreID : ".loadmore",
            tempDiv = templateID ? templateID : "#filter-template",
            galleryTemp = templateID ? templateID : "#gallery-template",
            resultDiv = resultId ? resultId : "#filter-template-result",
            dataPageSize = $('#templateInitializor').data('page-size');

        $.get(url, 
            function (data) {
            
            if (data.error == null) {
                var source = $(tempDiv).html(),
                    template = Handlebars.compile(source),
                    html = template(data.filters);
                    if (!$('.select2').length) {
                        $('.selectFilters').html(html);
                    }

                    if ($('.selectFilters .js-example-basic-single').length) {
                        $('.js-example-basic-single').select2();
                    }

                var source2 = $(galleryTemp).html(),
                    template2 = Handlebars.compile(source2);
                    $('.spinner').remove();
                    for (var j = 0; dataPageSize > j; j++){
                        $(resultDiv).append(template2(data.results.results[j]));
                    }

                    if (data.results != null && dataPageSize < data.results.Totalcount) {
                        $(".loadmore").show();
                    } else {
                        $(".loadmore").hide();
                    }
                    filterOnChange();
                    _fancyboxImage();
                    $(".loadmore").attr({ "CurrentPage": data.results.Totalcount });
            } else {}
        });
    }

    var _svg = function () {
        $("img.svg").each(function () {
            var $img = $(this);
            var imgID = $img.attr('id');
            var imgClass = $img.attr('class');
            var imgURL = $img.attr('src');
            $.get(imgURL, function (data) {
                // Get the SVG tag, ignore the rest
                var $svg = $(data).find('svg');
                // Add replaced image's ID to the new SVG
                if (typeof imgID !== 'undefined') {
                    $svg = $svg.attr('id', imgID);
                }
                // Add replaced image's classes to the new SVG
                if (typeof imgClass !== 'undefined') {
                    $svg = $svg.attr('class', imgClass + ' replaced-svg');
                }
                // Remove any invalid XML tags as per http://validator.w3.org
                $svg = $svg.removeAttr('xmlns:a');
                // Replace image with new SVG
                $img.replaceWith($svg);
            }, 'xml');
        });
    }

    var _dot = function () {
        $(".dotdotdot").dotdotdot({
            ellipsis: '... '
        });
    }

    return {
        // To Init
        tabs: function (url, tabClass, tabContentClass, pagination) {
            _tabs(url, tabClass, tabContentClass, pagination);
        },

        // To Init
        filter: function (url, pagination, loadmoreID, templateID, resultId) {
            _filter(url, pagination, loadmoreID, templateID, resultId);
        },

        results: function(url, pagination, loadmoreID, templateID, resultId) {
            _results(url, pagination, loadmoreID, templateID, resultId);
        },

        svg: function () {
            _svg();
        },

        dot: function () {
            _dot();
        }
    };
})(jQuery);