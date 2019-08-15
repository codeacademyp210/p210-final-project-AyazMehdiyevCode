'use strict'

$(document).ready(function(){
    let spans =  $(".topFive>div:nth-child(2) span")  
    let tabs = $('.tab')
    spans.click(function(){
        spans.each(function(){
         $(this).removeClass('active-tab-btn');
        });
        $(this).addClass('active-tab-btn');

        let tabindex = $(this).data("tab")
        
        tabs.each(function(){
            $(this).removeClass("active-tab");
        })
        $(tabs.get(tabindex)).addClass("active-tab");
    });
    
});
