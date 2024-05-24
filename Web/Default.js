$(document).ready(function () {
    let slideIndex = 0;
    showSlides();

    function showSlides() {
        let slides = $(".mySlides");
        slides.each(function () {
            $(this).css('display', 'none');
        });

        slideIndex++;
        if (slideIndex > slides.length) {
            slideIndex = 1;
        }

        slides.eq(slideIndex - 1).css('display', 'block');
        setTimeout(showSlides, 7000); //7 seg cambio
    }
});