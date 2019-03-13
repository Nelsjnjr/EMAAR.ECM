$(document).ready(function () {
    //initialize swiper when document ready
   
    let mySwiper = new Swiper('#video-slider-wrapper .video-slider-container', {
        // Optional parameters
        // direction: 'vertical',
     
        loop: true,
        slidesPerView: 3,
        spaceBetween: 20,
        // centeredSlides: true,
        // autoplay: {
        //     delay: 2500,
        //     disableOnInteraction: false,
        // },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        breakpoints: {
         
            // 1024: {
            //     slidesPerView: 3,
            //     // spaceBetween: 40,
            //     // centerMode: true,
            //     slidesPerView: 'auto',
            //     // centeredSlides: true,
            //     spaceBetween: 5,
            //     // freeMode: true,
                
            // },
            768: {
                // spaceBetween: 5,
                slidesPerView: 2,
            },
            767: {
                spaceBetween: 5,
                slidesPerView: 1,
            },
          
          
        }
    });

    // let width = $('.swiper-slide').innerWidth();
    // let length = $('.swiper-slide').length;
    // let width1 = (width*length);
    // $('.video-slider-container').css('width',width1);

    // mySwiper.swipeTo(0, 1, true); 

    $(".video-slider__link").fancybox({
        maxWidth: '100%',
        maxHeight: '100%',
        fitToView: true,
        width: '100%',
        height: '100%',
        autoSize: true,
        closeClick: true,
        openEffect: 'fade',
        closeEffect: 'fade',
        type: "iframe",
    });
});