// global Variables
var winWidth = $(window).width(),
    mobileWidth = 767,
    tabletPWidth = 991,
    languageCode = $('body').attr("lang"),
    totalCount = $('.loadmore').data('total-count'),
    dataPageSize = $('#templateInitializor').data('page-size'),
    total = dataPageSize,
    AjaxUrl = $('#templateInitializor').data('service-url');

// page init
jQuery(function () {
    getImageGallery();
   loadMore();
});

function isNullUndefinedOrWhiteSpace(str) {
    return str === undefined || str === null ? true : !/\S/.test(str);
}

function filterOnChange() {
    $('.js-example-basic-single').on('change', function(){
        getImageGalleryOnChange();
    });
}


function getImageGallery(pagination){
    var parameterlabel= [],
        n = 0;

    $('.filters-support').each(function(){
        var $this = $(this);
        var $value = $this.val();
        parameterlabel[n] = {Label: $this.data('label'), Value: $value};
        n++;
    });

    if (parameterlabel.length) {
        for(index in parameterlabel) {
            AjaxUrl = AjaxUrl +"?" + parameterlabel[index].Label + "=" + parameterlabel[index].Value;
        }
    } else {
        AjaxUrl = AjaxUrl + "?";
    }

    // var JSONurl = AjaxUrl + "?" + yearLabel + "=" + year + "&" + albumLabel + "=" + albums;
    getData.filter(AjaxUrl, pagination);
}

function getImageGalleryOnChange(pagination){
    var parameterlabel= [],
        n = 0;
        
    $('.filters-support').each(function(){
        var $this = $(this);
        var $value = $this.val();
        parameterlabel[n] = {Label: $this.data('label'), Value: $value};
        n++;
    });

    if (parameterlabel.length) {
        for(index in parameterlabel) {
            AjaxUrl = AjaxUrl +"?" + parameterlabel[index].Label + "=" + parameterlabel[index].Value;
        }
    }

    // var JSONurl = AjaxUrl + "?" + yearLabel + "=" + year + "&" + albumLabel + "=" + albums;
    getData.results(AjaxUrl, pagination);
}

function loadMore() {
    $('.loadmore').on('click', function() {
        if (total < totalCount) {
            total += dataPageSize;
            $('#templateInitializor').data('page-size', total);
            getImageGalleryOnChange(); 
        }
    });
}