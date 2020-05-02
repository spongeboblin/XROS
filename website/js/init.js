$(document).ready(function(){
$('.sidenav').sidenav();
});

var el = document.querySelector('.tabs');
var instance = M.Tabs.init(el,{});

$(document).ready(function(){
  $('.materialboxed').materialbox();
});

(function($){
  $(function(){

    $('.parallax').parallax();

  }); // end of document ready
})(jQuery); // end of jQuery name space

$(document).ready(function(){
  $('.slider').slider();
});
