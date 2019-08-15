'use strict'

$('document').ready(function(){

    /* marque */
$("#marque-news").mouseenter(function(){
	this.stop();
})
$("#marque-news").mouseleave(function(){
	this.start();
})

})