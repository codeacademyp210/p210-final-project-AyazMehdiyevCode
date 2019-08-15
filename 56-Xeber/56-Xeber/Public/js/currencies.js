'use strict'

$(document).ready(function(){
    $.ajax({url: " http://www.floatrates.com/daily/azn.json", success: function(result){
        $("#usd").text(result.usd.inverseRate.toFixed(2).toString());
        $("#euro").text(result.eur.inverseRate.toFixed(2).toString());
      }});
  });

// $(document).ready(function(){

//     let day = new Date().getDate();
//     let month = new Date().getMonth() + 1;
//     let year = new Date().getFullYear();
//     if(day<10){
//         day ="0" + day
//     }
//     if(month<10){
//         month = "0" + month
//     }
//     let FullDay = day + "." + month + "." + year
//     console.log(FullDay)

// });
