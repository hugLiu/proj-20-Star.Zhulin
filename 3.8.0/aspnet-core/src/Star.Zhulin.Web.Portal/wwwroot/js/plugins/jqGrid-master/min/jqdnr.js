!function(t,e){"use strict";"function"==typeof define&&define.amd?define(["jquery"],function(i){return e(i,t,t.document)}):"object"==typeof module&&module.exports?module.exports=function(t,i){return t||(t=window),void 0===i&&(i="undefined"!=typeof window?require("jquery"):require("jquery")(t)),e(i,t,t.document),i}:e(jQuery,t,t.document)}("undefined"!=typeof window?window:this,function(t,e,i){"use strict";var r="mousedown",n="mousemove",o="mouseup",d=function(t){var e=t.originalEvent.targetTouches;return e?(e=e[0],{x:e.pageX,y:e.pageY}):{x:t.pageX,y:t.pageY}},u={drag:function(t){var e=t.data,i=e.e,r=e.dnr,n=e.ar,o=e.dnrAr,u=d(t);return"move"===r.k?i.css({left:r.X+u.x-r.pX,top:r.Y+u.y-r.pY}):(i.css({width:Math.max(u.x-r.pX+r.W,0),height:Math.max(u.y-r.pY+r.H,0)}),o&&n.css({width:Math.max(u.x-o.pX+o.W,0),height:Math.max(u.y-o.pY+o.H,0)})),!1},stop:function(){t(i).off(n,u.drag).off(o,u.stop)}},a=function(e,a,s,f){return e.each(function(){(a=a?t(a,e):e).on(r,{e:e,k:s},function(e){var r,a,s,p,c,h,j=e.data,q={},m=function(t,e){return parseInt(t.css(e),10)||!1},l=function(t){return m(a,t)},g=function(t){return m(p,t)},y=d(e);if(!t(e.target).hasClass("ui-jqdialog-titlebar-close")&&!t(e.target).parent().hasClass("ui-jqdialog-titlebar-close")){if(a=j.e,p=!!f&&t(f),"relative"!==a.css("position"))try{a.position(q)}catch(t){}if(s={X:q.left||l("left")||0,Y:q.top||l("top")||0,W:l("width")||a[0].scrollWidth||0,H:l("height")||a[0].scrollHeight||0,pX:y.x,pY:y.y,k:j.k},c=!(!p||"move"===j.k)&&{X:q.left||g("left")||0,Y:q.top||g("top")||0,W:p[0].offsetWidth||g("width")||0,H:p[0].offsetHeight||g("height")||0,pX:y.x,pY:y.y,k:j.k},(r=a.find("input.hasDatepicker")).length>0)try{r.datepicker("hide")}catch(t){}return h={e:a,dnr:s,ar:p,dnrAr:c},t(i).on(n,h,u.drag),t(i).on(o,h,u.stop),!1}})})};e.PointerEvent?(r+=".jqGrid pointerdown.jqGrid",n+=".jqGrid pointermove.jqGrid",o+=".jqGrid pointerup.jqGrid"):e.MSPointerEvent?(r+=".jqGrid mspointerdown.jqGrid",n+=".jqGrid mspointermove.jqGrid",o+=".jqGrid mspointerup"):(r+=".jqGrid touchstart.jqGrid",n+=".jqGrid touchmove.jqGrid",o+=".jqGrid touchend.jqGrid"),t.jqDnR=u,t.fn.jqDrag=function(t){return a(this,t,"move")},t.fn.jqResize=function(t,e){return a(this,t,"resize",e)}});
//# sourceMappingURL=jqdnr.js.map