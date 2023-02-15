
//  responsive sidebar
var $window = $(window);
var widthwindow = $window.width();
var $nav = $(".sidebar-wrapper");
var $header = $(".page-header");
var $toggle_nav_top = $(".toggle-sidebar");

(function ($) {
  "use strict";
  if (widthwindow <= 1400) {
    $toggle_nav_top.attr("checked", false);
    $nav.addClass("close_icon");
    $header.addClass("close_icon");
  }
})(jQuery);
$(window).resize(function () {
  var widthwindaw = $window.width();
  if (widthwindaw <= 1400) {
    $toggle_nav_top.attr("checked", false);
    $nav.addClass("close_icon");
    $header.addClass("close_icon");
  } 
  else if (widthwindaw => 1400) {
    $toggle_nav_top.attr("checked", true);
    $nav.removeClass("close_icon");
    $header.removeClass("close_icon");
  }
});