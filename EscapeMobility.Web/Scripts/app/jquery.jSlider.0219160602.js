(function($){
    $.jSlider = {
        defaults : {
            orientation : "horizontal",
            speed : 500,
            visible : 4,
            loop : false,
            btn1 : null, // Left or Bottom btn
            btn2 : null, // Right or Top btn
			interval : null, // MS if we need a interval
			
			// Events
			beforeShow : function(oldIndex, newIndex, oldElem, newElem){			
			}
        }
    };
	
	var methods = {
		init : function()
		{
			var _this = $(this),
				settings = _this.data("settings"),
				children = _this.children();
				
			settings.index = 0;
			
			// Set numbers
			children.each(function(i){
				$(this).attr("data-pos", i);
			});
			
			// Init btn1 (left or top)
			if( settings.btn1 )
			{
				if( typeof(settings.btn1).toString().toLowerCase() == "string" )
				{
					settings.btn1 = $(settings.btn1);
				}
				
				settings.btn1.click(function(){
					methods.btn1Click.call(_this);
				});
			}
			
			if( settings.btn2 )
			{
				if( typeof(settings.btn2).toString().toLowerCase() == "string" )
				{
					settings.btn2 = $(settings.btn2);
				}
				
				settings.btn2.click(function(){
					methods.btn2Click.call(_this);
				});
			}
			
			if( settings.interval )
			{
				methods.restartIntervalTimer.call(_this);
			}
		},
		// Left or Down btn clicked
		btn1Click : function()
		{
			var _this = $(this),
				settings = _this.data("settings"),
				anim = {},
				size = 0,
				side = null,
				children = _this.children();
			
			// If animated or less children then items visible, we can't scroll
			if( _this.is(":animated") || children.length <= settings.visible ) return;
			
			// Handle by orientation
			switch(settings.orientation)
			{
				case "horizontal":
					size = Math.abs( children.eq(settings.index).outerWidth(true) );
					side = "left";
					anim = {
						"left" : "+=" + -size
					};
				break;
				case "vertical":
					size = Math.abs( children.eq(settings.index).outerHeight(true) );
					side = "top";
					anim = {
						"top" : "-=" + size
					}
				break;
			}
			
			// If last item, loop? or stop animation
			if( settings.index == (children.length - settings.visible) )
			{
				if(settings.loop)
				{
					settings.index--;
					_this.css(side, "+=" + size)
						.children()
						.eq(0)
							.appendTo(_this);
				}
				else
				{
					return false;
				}
				// Before is does anything
				settings.beforeShow.call(_this, settings.index + 1, 0, children.eq(settings.index + 1), children.eq(0));
			}
			else
			{
				// Before is does anything
				settings.beforeShow.call(_this, settings.index, settings.index + 1, children.eq(settings.index), children.eq(settings.index + 1));				
			}
			
			// Increase index, animate
			settings.index++;

			_this.animate(anim, settings.speed, function(){
				// Reset timer
				if( settings.interval )
				{
					methods.restartIntervalTimer.call(_this);
				}										 
			});
		},
		// Right or Top btn clicked
		btn2Click : function()
		{
			var _this = $(this),
				settings = _this.data("settings"),
				anim = {},
				size = 0,
				side = null,
				children = _this.children();
			
			// If animated or less children then items visible, we can't scroll
			if( _this.is(":animated") || children.length <= settings.visible ) return;

			// Handle by orientation
			switch(settings.orientation)
			{
				case "horizontal":
					size = Math.abs( children.eq(settings.index - 1).outerWidth(true) );
					side = "left";
					anim = {
						"left" : "-=" + -size
					};
				break;
				case "vertical":
					size = Math.abs( children.eq(settings.index - 1).outerHeight(true) );
					side = "top";
					anim = {
						"top" : "+=" + size
					}
				break;
			}
			
			// If last item, loop? or stop animation
			if( settings.index == 0 )
			{
				if(settings.loop)
				{
					settings.index++;
					_this.css(side, "-=" + size)
						.children()
						.last()
							.prependTo(_this);
				}
				else
				{
					return false;
				}
				// Before is does anything
				settings.beforeShow.call(_this, 0, children.length - 1, children.eq(0), children.eq(children.length - 1));
			}
			else
			{
				// Before is does anything
				settings.beforeShow.call(_this, settings.index, settings.index - 1, children.eq(settings.index), children.eq(settings.index - 1));				
			}
			
			// animate
			// Decrease index, 
			settings.index--;
			_this.animate(anim, settings.speed, function(){
				// Reset timer
				if( settings.interval )
				{
					methods.restartIntervalTimer.call(_this);
				}										 
			});
		},
		// Reset interval Timer
		restartIntervalTimer : function()
		{
			 var _this = $(this),
				settings = _this.data("settings");
			
			if( settings.interval_timer )
			{
				clearTimeout(settings.interval_timer);	
			}
			
			if( settings.pause )
			{
				return;	
			}
			
			settings.interval_timer = setTimeout(function(){
				methods.btn1Click.call(_this);	
			}, settings.interval);
		}
	};
	
	var public = {
		pause : function()
		{
			var _this = $(this),
				settings = _this.data("settings");
			
			if( settings.interval_timer )
			{
				clearTimeout(settings.interval_timer);	
			}
			
			settings.pause = true;
		},
		play : function()
		{
			var _this = $(this),
				settings = _this.data("settings");
			
			settings.pause = false;
			methods.restartIntervalTimer.call(_this);
		},
		backToOriginalPositions: function()
		{
			var _this = $(this),
				children = _this.children();
				
			var a = [];
			var o = {}
		 
			children.each(function(){
				var t = parseInt($(this).attr("data-pos")); 
				a.push(t);			
				o[t] = this; 
			})
		 
			a.sort(function(a, b){return a - b;}); 
		 
			for (var i = 0; i<a.length; i++) 
			{
				_this.append(o[a[i]]); 
			}
		},
		getPrevAllWidth : function(currentEl){
			var offset = 0;
			currentEl.prevAll(":visible").each(function(){
				offset += $(this).outerWidth();								  
			});
			return offset;
		},
		scrollTo : function(newIndex)
		{
			var _this = $(this),
				settings = _this.data("settings"),
				anim = {},
				size = 0,
				side = null,
				children = _this.children(),
				direction = newIndex > settings.index ? "forward" : "backward",
				currentEl = children.eq(settings.index),
				nIndex = newIndex;
			
			// If animated or less children then items visible, we can't scroll
			if( _this.is(":animated") || children.length <= settings.visible || nIndex == settings.index ) return;

			// --------------------------
			// 	Reset positions
			
			// Move back to original order and set right positions
			public.backToOriginalPositions.call(_this);
			
			// Reset position
			_this.css("left", -public.getPrevAllWidth(currentEl));
			
			// Reset index
			settings.index = currentEl.index();
			
			//-------------------------
			// Now start moving
			

			// Hide elements in between
			var hiddenList = $.grep(children, function(n, i){
				switch(direction)
				{
					case "forward":
						return i > settings.index && i < nIndex;
					break;
					case "backward":
						return i < settings.index && i > nIndex;					
					break;
				}
			});
			
			$(hiddenList).hide();
			
			// Move
			switch(direction)
			{
				case "forward":
					// First animate, and then make new elements visible, and then set new offset
					//	otherwise we can't directly move to a new element ( H would be hidden )
					//	S H H S ( H will be hidden, so S will get to the front, when we show H again, we will see the wrong element, thats why we need to reposition S2 )
					//	> > > >
					_this.animate({left : -public.getPrevAllWidth(_this.children().eq(nIndex))}, settings.speed, function(){
						$(hiddenList).show();
						_this.css("left", -public.getPrevAllWidth(_this.children().eq(nIndex)));																						
					});
				break;
				case "backward":
					// First reset position, because elements are hidden
					//		now move it and then show the elements again which were hidden ( H would be hidden )
					//		S H H S ( second S will jump 2 positions back when H is hidden, that's why we need to set new left and then animate )
					//		< < < <
					_this.css("left", -public.getPrevAllWidth(_this.children().eq(settings.index)));			
					_this.animate({left : -public.getPrevAllWidth(_this.children().eq(nIndex))}, settings.speed, function(){
						$(hiddenList).show();																					
					});
				break;
			}
			
			settings.beforeShow.call(_this, settings.index, nIndex, _this.children().eq(settings.index), _this.children().eq(nIndex));
			settings.index = nIndex;
			
			// Reset timer
			if( settings.interval )
			{
				methods.restartIntervalTimer.call(_this);
			}	
		}
	};
	
    $.fn.jSlider = function()
    {
        var settings = arguments[0];
		if( typeof(settings) == "string" )
		{
			return public[settings].apply( this, Array.prototype.slice.call( arguments, 1 ));
		}
        var options = $.extend({}, $.jSlider.defaults, settings);
        return this.each(function(){
            $(this).data("settings", options);
            methods.init.call(this);
        });
    };
})(jQuery);