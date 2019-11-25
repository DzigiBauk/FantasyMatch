$(document).ready(function(){
    $(window).scroll(function () {
       $('.go-up').fadeIn();
        if($(this).scrollTop()==0){
         $('.go-up').fadeOut();
        }
         else if ($(this).scrollTop() + $(window).height() > $(document).height() - 1) {
         	$('.go-up').fadeOut();
         }
    });
});