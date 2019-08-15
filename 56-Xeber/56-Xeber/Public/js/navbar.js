'use strict'

$("document").ready(function(){
   
/* btnMenu */
    $("#btnMenu").click(function(){
		$("#I-navbar ul").stop(true,true).slideToggle("slow");
	})
	$("#I-navbar li").click(function(){
		if($("#I-navbar ul").css('display') == 'block'){
			$("#I-navbar ul").stop(true, true).slideUp("slow")
		}
	})
/* navbar sticky */
    var InavbarTop = $('#I-navbar').offset().top;

		   	var setSticky = function(){
			    var scrollTop = $(window).scrollTop();
			    if (scrollTop > InavbarTop) { 
					$('#I-navbar').addClass('sticky');
					$('.pageTo-Top').stop().fadeIn(); 
			    } else {
			        $('#I-navbar').removeClass('sticky'); 
					$('.pageTo-Top').stop().fadeOut(); 
			    }
            };
            
            setSticky();
            
			$(window).scroll(function() {
				setSticky();
			});

});

