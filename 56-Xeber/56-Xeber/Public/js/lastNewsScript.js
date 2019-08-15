'use strict'
/* lastnews image fade */
$(document).ready(function(){
    $('.lastNews li').mouseenter(function(){
        $(this).children("img").stop().fadeIn();
    });
    $('.lastNews li').mouseleave(function(){
        $(this).children("img").stop().fadeOut();
    });
});
