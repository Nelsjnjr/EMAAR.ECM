'use strict';

/* To get JSON DATA  */
var getData = (function ($) {

        var spinner = '<div class="spinner">\<div class="double-bounce1"></div><div class="double-bounce2"></div></div>';
        // To get the Forum tabs data and populate it accordingly
        var _tabs = function(url, tabClass, tabContentClass, pagination){
         
         // For loading
         $("#tabs-head-result").html(spinner);

         // To get Data
         $.get(url, function(data) {
            if (data.error == null)
            {

                var source   = $("#tabs-head").html(),
                    template = Handlebars.compile(source),
                    html    = template(data.Result);
                $("#tabs-head-result").html(html);


                var source2   = $("#tabs-content").html(),
                    template2 = Handlebars.compile(source2),
                    html2    = template2(data.Result);
                $("#tabs-content-result").html(html2);

                var tabIndex = $(tabClass).find(".active").attr("data-tab-index");
                $(tabContentClass).hide();
                $(tabContentClass).each(function(){
                    if($(this).attr("data-tab") == tabIndex){
                        $(this).fadeIn();
                    }
                })

                $(tabClass).find("li").click(function(){
                    if($(this).hasClass("disbaled")){
                        return false
                    }
                    $(this).addClass("active").siblings().removeClass("active");
                    var tabIndex =  $(this).attr("data-tab-index");
                    $(tabContentClass).hide();
                    $(tabContentClass).each(function(){
                        if($(this).attr("data-tab") == tabIndex){
                            $(this).fadeIn();
                        }
                    })
                })


            }else{	    		
            }
         })
    }

        var _filter = function(url, pagination, loadmoreID, templateID, resultId){
            // For loading
            var loadID = loadmoreID ? loadmoreID : ".loadmore",
                tempDiv = templateID ? templateID : "#filter-template" ,
                resultDiv = resultId ? resultId : "#filter-template-result" ;
            
            if(!pagination){
                $(resultDiv).html(spinner);
                url = url + "&page=1";
            } else {
                var currentPage = $(loadID).attr("CurrentPage");
                url = url + "&page=" + (parseInt(currentPage)+1);
            }

            // To get Data
            $.get(url,
                function(data) {
                    if (data.error == null) {
                        var source = $(tempDiv).html(),
                            template = Handlebars.compile(source),
                            html = template(data.Result);

                        if (pagination) {
                            $(resultDiv).append(html);
                        } else {
                            $(resultDiv).html(html);
                        }

                        var currentPage = 1;

                        if (data.Result != null)
                        {

                            currentPage = data.Result.CurrentPage;

                            if(data.Result.CurrentPage < data.Result.TotalPage)
                            {
                                $(loadID).show();
                            }
                            else {
                                $(loadID).hide();
                            }
                            
                            if (eval($("span.searchCount").html()) >= 0)
                            {
                                $("span.searchCount").html(data.Result.TotalCount);
                            }
                            if (data.Result.Data) {
                                $(loadID).attr({ "data-lastIndex": data.Result.Data[data.Result.Data.length - 1].index });
                            }
                            
                        } else {
                            $(loadID).hide();
                        }

                        $(loadID).attr({ "CurrentPage": currentPage });
                        _svg();
                        _dot();
                        $('[data-toggle="tooltip"]').tooltip(); 

                    } else {
                    }
                });
        }

        var _svg = function() {
            $("img.svg").each(function() {
                    var $img = $(this);
                    var imgID = $img.attr('id');
                    var imgClass = $img.attr('class');
                    var imgURL = $img.attr('src');
                $.get(imgURL, function(data) {
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

        var _dot = function (){
            $(".dotdotdot").dotdotdot({
               ellipsis: '... '
            });
        }

        return {
            // To Init
            tabs: function(url, tabClass, tabContentClass, pagination){
            _tabs(url, tabClass, tabContentClass, pagination);
            },

            // To Init
            filter: function(url, pagination, loadmoreID, templateID, resultId){
            _filter(url, pagination, loadmoreID, templateID, resultId);
            },

            svg: function(){
                _svg();
            },

            dot: function(){
                _dot();
            }
        };
})(jQuery);
