'use strict'

$(document).ready(function(){
    $.ajax({url: "http://api.openweathermap.org/data/2.5/weather?q=Baku,az&APPID=1dec7431ebc16d3a42400bba136450f1&units=metric", success: function(result){
        $("#Temp").text(result.main.temp);
        $("#Wind").text((result.wind.speed*3.6).toFixed(2));
      }});
  });