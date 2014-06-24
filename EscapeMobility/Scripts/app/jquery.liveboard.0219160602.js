(function($) {
$.fn.extend({
		/*
			Liveboard
			----------------------
			Version		: 0.1
			----------------------			
			Structure	:
			----------------------
				<div class="liveboard">
					<ul id="contentUL">
						<li>CONTENT HERE</li>
						<li>CONTENT HERE</li>
						<li>CONTENT HERE</li>					
					</ul>
					<ul id="menuUL">
						<li class="exclude">MENU HEADER</li>
						<li>MENU ITEM</li>
						<li>MENU ITEM</li>
						<li>MENU ITEM</li>
					</ul>
				</div>
			----------------------			
		*/
		liveboard : function(options, arg1){

			var defaults = {
			    liveboardID             : null,     // Id of the liveboard
				contentUL				: null,		// List from the content items
				menuUL					: null,		// List from the menu items
				menuULExcludeFirstUL 	: false,	// It can happen that the first menu item is the menu header, so exclude or not?
				contentSlideText		: null,		// The content image will fade in, and then the tekst will slide down
				
				useInterval				: false,		// Automaticly go to the next element, next interval is called after animation is completed
				intervalTime			: 5000			// Time to next item in MS
			};
	
			var settings = $.extend(defaults, options);
			
			method = {
				/*
					Init the module
				*/
				init : function(){
					// Hide all other content
					$(settings.liveboardID).find(settings.contentUL).find("li").addClass("liveboard-item").first().nextAll().hide();
					
					// Select first menu item
					if(settings.menuULExcludeFirstUL)
					{
						// Set selected, exclude first
						$(settings.liveboardID).find(settings.menuUL).find("li").first().next().addClass("selected").nextAll().removeClass("selected");
						
						// Make clickable
						$(settings.liveboardID).find(settings.menuUL).find("li").first().nextAll().addClass("liveboard-item").click(method.selectItem);
					}
					else
					{
						// set selected
						$(settings.liveboardID).find(settings.menuUL).find("li").first().addClass("selected").nextAll().removeClass("selected");
						
						// Make clickable
						$(settings.liveboardID).find(settings.menuUL).find("li:not([exclude])").addClass("liveboard-item").click(method.selectItem);
					}
					
					// Hide the content text box
					if(settings.contentSlideText)
					    $(settings.liveboardID).find(settings.contentSlideText).hide().eq(0).show();
					
					// Interval
					if(settings.useInterval)
					{
						$(settings.liveboardID).data("interval", setTimeout(method.nextItem, settings.intervalTime));
					}
				},
				/*
					Select the next item
				*/
				nextItem : function()
				{
					var $menu = $(settings.liveboardID).find(settings.menuUL);
					var oldIndex = method.indexOf.call($menu.find(".selected"));
					var newIndex = oldIndex + 1;
					
					if(oldIndex == $menu.find(".liveboard-item:not([exclude])").length - 1)
					{
						newIndex = 0;
					}
					
					method.selectItem.call($menu.find(".liveboard-item").eq(newIndex));
				},
				/*
					Select a new item
						this = menuLI item
				*/
				selectItem : function()
				{
					// Clear interval
					if(settings.useInterval)
					{
						clearTimeout($(settings.liveboardID).data("interval"));
					}
					// Set selected class
					$(this).addClass("selected").siblings(".liveboard-item").removeClass("selected");
					
					// Fade to right content
					var index = method.indexOf.call($(this));
					
					// No content to slide, just fade
					if(settings.contentSlideText === null)
					{
					    $(settings.contentUL)
							.find(".liveboard-item:visible")
							.fadeOut("normal");
							
						$(settings.contentUL)
							.find(".liveboard-item")
							.eq(index)
							.fadeIn("normal", function(){
								// Set new interval
								if(settings.useInterval)
								{
									$(settings.liveboardID).data("interval", setTimeout(method.nextItem, settings.intervalTime));
								}
							})
					}
					// We got content to slide. So set this up!
					else
					{	
						// Slide down the visible tekst box
						$(settings.contentUL)
								.find(".liveboard-item:visible")
								.find(settings.contentSlideText)
								.slideUp("slow", function(){
										
										// Fade out the visible box
										$(settings.contentUL)
											.find(".liveboard-item:visible")
											.fadeOut("normal");
										
										// Fade in the new box
										$(settings.contentUL)
											.find(".liveboard-item")
											.eq(index)
											.fadeIn("normal", function(){
												// SLide up the content text
												$(this).find(settings.contentSlideText).slideDown("slow");
												
												// Set new interval
												if(settings.useInterval)
												{
													$(settings.liveboardID).data("interval", setTimeout(method.nextItem, settings.intervalTime));
												}
											});
								});
					}
				},
				/*
					Get the index of a menu item or content item (LI)
				*/
				indexOf : function()
				{
					return $(this).parent().find(".liveboard-item").index($(this));	
				}
			};
			
			if(typeof(options) == "string")
			{
				method[options].call(this, arg1);
				return this;	
			}
			return this.each(function(){
				method.init.call();
			});	
		}
    });

})(jQuery);
// JavaScript Document