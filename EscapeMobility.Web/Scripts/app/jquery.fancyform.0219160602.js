/*
* Fancyform - jQuery Plugin
* Simple and fancy form styling alternative
*
* Examples and documentation at: http://www.lutrasoft.nl/jQuery/fancyform/
* 
* Copyright (c) 2010-2011 - Lutrasoft
* 
* Version: 1.2.2 (17/11/2011)
* Requires: jQuery v1.3.2+ 
*
* Dual licensed under the MIT and GPL licenses:
*   http://www.opensource.org/licenses/mit-license.php
*   http://www.gnu.org/licenses/gpl.html
*/
(function ( $ )
{
    $.fn.extend( {
        /*
        Get the caret on an textarea
        */
        caret: function ( start, end )
        {
            var elem = this[0];

            if ( elem ) {
                // get caret range
                if ( typeof start == "undefined" ) {
                    if ( elem.selectionStart ) {
                        start = elem.selectionStart;
                        end = elem.selectionEnd;	
                    }
					// <= IE 8
                    else if ( document.selection ) {
                        var val = this.val();
						this.focus();
						
						var r = document.selection.createRange();
						if (r == null) {
							return { start: 0, end: e.value.length, length: 0 }
						}
	
						var re = elem.createTextRange();
						var rc = re.duplicate();
						re.moveToBookmark(r.getBookmark());
						rc.setEndPoint('EndToStart', re);			
						
						// IE counts a line (not \n or \r) as 1 extra character
						return { start: rc.text.length - (rc.text.split("\n").length + 1) + 2, end: rc.text.length + r.text.length - (rc.text.split("\n").length + 1) + 2, length: r.text.length, text: r.text };
                    }
                }
                // set caret range
                else {
                    var val = this.val();

                    if ( typeof start != "number" ) start = -1;
                    if ( typeof end != "number" ) end = -1;
                    if ( start < 0 ) start = 0;
                    if ( end > val.length ) end = val.length;
                    if ( end < start ) end = start;
                    if ( start > end ) start = end;

                    elem.focus();

                    if ( elem.selectionStart ) {
                        elem.selectionStart = start;
                        elem.selectionEnd = end;
                    }
                    else if ( document.selection ) {
                        var range = elem.createTextRange();
                        range.collapse( true );
                        range.moveStart( "character", start );
                        range.moveEnd( "character", end - start );
                        range.select();
                    }
                }

                return { start: start, end: end };
            }
        },

        /*
        Replace radio buttons with images
        */
        transformRadio: function ( options )
        {

            var defaults = {
                checked: "/img/content/radio_checked.gif",
                unchecked: "/img/content/radio.gif"
            };

            var options = $.extend( defaults, options );

            return this.each( function ()
            {
                
                // Is already initialized
                if( $( this ).data("transformRadio.initialized") === true )
                {
                    return this;
                }
                
                // set initialized
                $( this ).data("transformRadio.initialized", true);
                
                // Radio hide
                $( this ).hide();

                // Afbeelding
                if ( $( this ).is( ":checked" ) ) {
                    $( this ).after( "<img src='" + options.checked + "' />" );
                }
                else {
                    $( this ).after( "<img src='" + options.unchecked + "' />" );
                }

                $( this ).next( "img" ).first().click( function ()
                {
                    var name = $( this ).prev().attr( "name" );
                    $( "[name='" + name + "']" ).removeAttr( "checked" ).next().attr( "src", options.unchecked );

                    $( this ).attr( "src", options.checked );
                    // Radio button checkedn
                    $( this ).prev( "input:radio" ).attr( "checked", "checked" );
                } );
            } );
        },
        /*
        Replace checkboxes with images
        */
        transformCheckbox: function ( settings )
        {

            var defaults = {
                checked: "/images/content/filterBoxCheckboxChecked.jpg",
                unchecked: "/images/content/filterBoxCheckbox.jpg",
                changeHandler: function ( is_checked ) { }
            };

            var options = $.extend( defaults, settings );

            var method = {
                uncheck: function ()
                {
                    // Afbeelding switchen
                    $( this ).attr( "src", options.unchecked );

                    // Radio button checkedn

                    $( this ).prev( "input:checkbox" ).removeAttr( "checked" );

                    $( this ).prev( "input:checkbox" ).change();
                },
                check: function ()
                {
                    // Afbeelding switchen
                    $( this ).attr( "src", options.checked );

                    // Radio button checkedn
                    $( this ).prev( "input:checkbox" ).attr( "checked", "checked" );

                    $( this ).prev( "input:checkbox" ).change();
                },
                imageClick: function ()
                {
                    if ( $( this ).prev().is( ":checked" ) ) {
                        method.uncheck.call( this );
                        options.changeHandler.call( $( this ).prev(), true );
                    }
                    else {
                        method.check.call( this );
                        options.changeHandler.call( $( this ).prev(), false );
                    }
                }
            }

            return this.each( function ()
            {
                if ( typeof ( settings ) == "string" ) {
                    method[settings].call( $( this ).next( "img" ) );
                }
                else {
                    // Is already initialized
                    if( $( this ).data("transformCheckbox.initialized") === true )
                    {
                        return this;
                    }
                    
                    // set initialized
                    $( this ).data("transformCheckbox.initialized", true);
                    
                    // Radio hide
                    $( this ).hide();

                    // Afbeelding
                    if ( $( this ).is( ":checked" ) ) {
                        $( this ).after( "<img src='" + options.checked + "' />" );
                    }
                    else {
                        $( this ).after( "<img src='" + options.unchecked + "' />" );
                    }

                    $( this ).next( "img" ).click( method.imageClick );
                }
            } );
        },
        /*
        Replace select with list
        =========================
        HTML will look like
        <ul>
        <li><span>Selected value</span>
        <ul>
        <li><span>Option</span></li>
        <li><span>Option</span></li>
        </ul>
        </li>
        </ul>
        */
        transformSelect: function ( options )
        {
            var defaults = {
                dropDownClass: "transformSelect",
                showFirstItemInDrop: true,
                acceptManualInput: false,

                subTemplate: function () { return "<span>" + $( this ).text() + "</span>"; },
                initValue: function () { return $( this ).text(); },
                valueTemplate: function () { return $( this ).text(); }
            };

            var options = $.extend( defaults, options );

            var method = {
                init: function ()
                {
                    // Hide mezelf
                    $( this ).hide();

                    // Generate HTML
                    var selectedIndex = -1;
                    if ( $( this ).find( "option:selected" ).length > 0 )
                        selectedIndex = $( this ).find( "option" ).index( $( this ).find( "option:selected" ) );
                    else
                        selectedIndex = 0;

                    // Maak een ul aan
                    var $ul = $( "<ul />" ).addClass( options.dropDownClass ).addClass( "trans-element" );
                    var $li = $( "<li />" );

                    if ( options.acceptManualInput ) {
                        var input = $( "<input type='text' />" )
											.click( method.openDrop )
											.keydown( function ( e )
											{
											    var ar = [9, 13]; // Tab or enter
											    if ( $.inArray( e.which, ar ) != -1 )
											        method.closeAllDropdowns();
											} );
                        input.attr( "name", $( this ).attr( "name" ) );
                        if ( $( this ).data( "value" ) )
						    input.val( $( this ).data( "value" ) );
						else
                            input.val( options.initValue.call( $( this ).find( "option" ).eq( selectedIndex ) ) );

                        $li.append( input );

                        // Save old select
                        $( this ).attr( "name", $( this ).attr( "name" ) + "_backup" );
                    }
                    else {
                        var $span = $( "<span />" ).click( method.openDrop );
                        $span.html( options.initValue.call( $( this ).find( "option" ).eq( selectedIndex ) ) );
                        $li.append( $span );
                    }


                    // span vullen met geselecteerde waarde
                    $ul.append( $li );
                    $li.append( "<ul />" );

                    var $drop = $li.find( "ul" );
                    $drop.hide();

                    $( this ).children().each( function ( i )
                    {
                        if ( i == 0 && options.showFirstItemInDrop == false ) {
                            // Don't do anything when you don't wanna show the first element
                        }
                        else {
                            var child = "";
                            switch ( $( this ).get( 0 ).tagName.toUpperCase() ) {
                                case "OPTION":
                                    child = method.getLIOptionChild.call( this );

                                    // Als er wordt geklikt op een nieuwe waarde
                                    child.click( method.selectNewValue );
                                    break;
                                case "OPTGROUP":
                                    child = method.getLIOptgroupChildren.call( this );
                                    break;
                            }
                            $drop.append( child );
                        }
                    } );
                    $( this ).after( $ul );

                    $( "html" ).click( method.closeDropDowns );
                },
                /*
                *	GET option child
                */
                getLIOptionChild: function ()
                {
                    return $( "<li />" ).append( options.subTemplate.call( $( this ) ) );
                },
                /*
                *	GET optgroup children
                */
                getLIOptgroupChildren: function ()
                {
                    var $li = $( "<li />" ).addClass( "group" );
                    var $span = $( "<span />" ).text( $( this ).attr( "label" ) ).appendTo( $li );
                    var $ul = $( "<ul />" ).appendTo( $li );

                    $( this ).find( "option" ).each( function ()
                    {
                        child = method.getLIOptionChild.call( this );

                        // Als er wordt geklikt op een nieuwe waarde
                        child.click( method.selectNewValue );

                        child.appendTo( $ul );
                    } );
                    return $li;
                },
                /*
                *	Select a new value
                */
                selectNewValue: function ()
                {
                    var index = 0;
                    if ( $( this ).closest( ".group" ).length != 0 ) {
                        index = $( this ).closest( ".group" ).parent().find( "li" ).index( $( this ) );
                        index -= $( this ).closest( ".group" ).prevAll( ".group" ).length;
                    }
                    else {
                        index = $( this ).parent().find( "li" ).index( $( this ) );
						if (options.showFirstItemInDrop == false) {
                            index += 1;
                        }
                    }

                    var $ul = $( this ).closest( ".trans-element" );

                    $ul.prev( "select" ).get( 0 ).selectedIndex = index;
                    $( ".trans-element" )
							    .find( "ul:eq(0)" )
							    .hide()
						    .parent()
						    .removeClass( "open" );

                    // If it has an input, there is no span used for value holding
                    if ( $ul.find( "input" ).length > 0 ) {
                        $ul.find( "input" ).val( options.valueTemplate.call( $( this ) ) );
                    }
                    else {
                        $ul
					        .find( "span:eq(0)" )
					        .html( options.valueTemplate.call( $( this ) ) );
                    }

                    // Trigger onchange
                    $( this ).closest( "ul.trans-element" ).prev( "select" ).trigger( "change" );
                },
                /*
                *	Open clicked dropdown
                *		and Close all others
                */
                openDrop: function ()
                {
                    $( this ).parent().find( "ul:eq(0)" ).css( { 'z-index': 100 } ).parent().css( { 'z-index': 100 } ).addClass( "open" );
                    $( this ).parent().find( "ul:eq(0)" ).show();

                    method.hideAllOtherDropdowns.call( this );
                },
                /*
                *	Hide all elements except this element
                */
                hideAllOtherDropdowns: function ()
                {
                    // Hide elements with the same class
                    var elIndex = $( "body" ).find( "*" ).index( $( this ).parent() );

                    $( "body" ).find( "ul.trans-element" ).each( function ()
                    {
                        if ( elIndex - 1 != $( "body" ).find( "*" ).index( $( this ) ) ) {
                            $( this ).find( "ul:eq(0)" ).hide().css( { 'z-index': 0 } ).parent().css( { 'z-index': 0 } ).removeClass( "open" );
                        }
                    } );
                },
                /*
                *	Close all dropdowns
                */
                closeDropDowns: function ( e )
                {
                    var $el = $( "." + options.dropDownClass ).find( "ul" );
                    if ( $( e.target ).closest( ".trans-element" ).length == 0 )
                        $( "ul.trans-element" ).find( "ul:eq(0)" ).hide().parent().removeClass( "open" );
                },
                closeAllDropdowns: function ()
                {
                    $( "ul.trans-element" ).find( "ul:eq(0)" ).hide().parent().removeClass( "open" );
                }
            }
            return this.each( function ()
            {
				// Is already initialized
                if( $( this ).data("transformSelect.initialized") === true )
                {
                    return this;
                }
                
                // set initialized
                $( this ).data("transformSelect.initialized", true);
				
				// Call init functions
                method.init.call( this );
                return this;
            } );
        },
        /*
        Transform a input:file to your own layout
        ============================================
        Basic CSS:
        <style>
        .customInput {
			display: inline-block;
			font-size: 12px;
		}
		
		.customInput .inputPath {
			width: 150px;
			padding: 4px;
			display: inline-block;
			border: 1px solid #ABADB3;
			background-color: #FFF;
			overflow: hidden;
			vertical-align: bottom;
			white-space: nowrap;
			-o-text-overflow: ellipsis;
			text-overflow:    ellipsis;
		}
		
		.customInput .inputButton {
			display: inline-block;
			padding: 4px;
			border: 1px solid #ABADB3;
			background-color: #CCC;
			vertical-align: bottom;
		}        </style>
        */
        transformFile: function ( options )
        {
			var method = {
				file : function(fn, cssClass) {
					return this.each(function() {
						var el = $(this);
						var holder = $('<div></div>').appendTo(el).css({
							position:'absolute',
							overflow:'hidden',
							'-moz-opacity':'0',
							filter:'alpha(opacity: 0)',
							opacity:'0',
							zoom:'1',
							width:el.outerWidth()+'px',
							height:el.outerHeight()+'px',
							'z-index':1
						});
				
						var wid = 0;
						var inp;
				
						var addInput = function() {
							var current = inp = holder.html('<input '+(window.FormData ? 'multiple ' : '')+'type="file" style="border:none; position:absolute">').find('input');
				
							wid = wid || current.width();
				
							current.change(function() {
								current.unbind('change');
				
								addInput();
								fn(current[0]);
							});
						};
						var position = function(e) {
							holder.offset(el.offset());
							if (e) {
								inp.offset({left:e.pageX-wid+25, top:e.pageY-10});
								addMouseOver();
							}
						};
				
						var addMouseOver =  function () {
							el.addClass(cssClass+'MouseOver');
						};
				
						var removeMouseOver =  function () {
							el.removeClass(cssClass+'MouseOver');
						};
				
						addInput();
				
						el.mouseover(position);
						el.mousemove(position);
						el.mouseout(removeMouseOver);
						position();
					});
				}	
			};
			
            return this.each( function ( i )
            {
				// Is already initialized
                if( $( this ).data("transformFile.initialized") === true )
                {
                    return this;
                }
                
                // set initialized
                $( this ).data("transformFile.initialized", true);
				
				// 
                var el = $(this);
				var id = null;
				var name = el.attr('name');
				var cssClass = (!options?'customInput':(options.cssClass?options.cssClass:'customInput'));
				var label = (!options?'Browse...':(options.label?options.label:'Browse...'));
	
				el.hide();
	
				if(!el.attr('id')){el.attr('id', 'custom_input_file_'+(new Date().getTime())+Math.floor(Math.random()*100000));}
				id = el.attr('id');
	
				el.after('<span id="'+id+'_custom_input" class="'+cssClass+'"><span class="inputPath" id="'+id+'_custom_input_path">&nbsp;</span><span class="inputButton">'+label+'</span></span>');
	
				method.file.call($('#'+id+'_custom_input'), function(inp) {
					inp.id = id;
					inp.name = name;
					$('#'+id).replaceWith(inp);
					$('#'+id).removeAttr('style').hide();
					$('#'+id+'_custom_input_path').html($('#'+id).val().replace(/\\/g, '/').replace( /.*\//, '' ));
				}, cssClass);
				
				return this;
            } );

        },
        /*
        Replace a textarea
        */
        transformTextarea: function ( options, arg1 )
        {
            var defaults = {
                hiddenTextareaClass: "hiddenTextarea"
            };

            var settings = $.extend( defaults, options );

            method = {
                // Init the module
                init: function ()
                {
                    // This only happens in IE
                    if ( $( this ).css( "line-height" ) == "normal" ) {
                        $( this ).css( "line-height", "12px" );
                    }

                    // Set the CSS
                    var CSS = {
                        'line-height': $( this ).css( "line-height" ),
                        'font-family': $( this ).css( "font-family" ),
                        'font-size': $( this ).css( "font-size" ),
                        "border": "1px solid black",
                        "width": $( this ).width(),
                        "letter-spacing": $( this ).css( "letter-spacing" ),
                        "text-indent": $( this ).css( "text-indent" ),
                        "padding": $( this ).css( "padding" ),
                        "overflow": "hidden",
                        "white-space": $( this ).css( "white-space" )
                    };

                    $( this )
                    // Add a new textarea
							.css( CSS )
							.keyup( method.keyup )
							.keydown( method.keyup )
                    // Append a div
						.after( $( "<div />" ) )
							.next()
							.addClass( settings.hiddenTextareaClass )
							.css( CSS )
							.css( "width", $( this ).width() - 5 )	// Minus 5 because there is some none typeable padding?
							.hide()
							;
                },

                // Used to scroll 
                keyup: function ( e )
                {
                    // Check if it has to scroll
                    // Arrow keys down have to scroll down / up (only if to far)
                    /*
                    Keys:
                    37, 38, 39, 40  = Arrow keys (L,U,R,D)
                    13				= Enter
                    */					
                    var ignore = [37, 38, 39, 40];
                    if ( $.inArray( e.which, ignore ) != -1 ) {
                        method.checkCaretScroll.call( this );
                    }
                    else {
                        method.checkScroll.call( this, e.which );
                    }
					
					method.scrollCallBack.call(this);
                },
                /*
                Check cursor position to scroll
                */
                checkCaretScroll: function ()
                {
                    var src = $( this );
                    var caretStart = src.caret().start;
                    var textBefore = src.val().substr( 0, caretStart );
					var textAfter = src.val().substr(caretStart, src.val().length);
                    var tar = src.next( "." + settings.hiddenTextareaClass );
                    var vScroll = null;

                    // First or last element (don't do anything)
                    if ( !caretStart || caretStart == 0 )
					{
                        return false;
					}

                    // Also pick the first char of a row
                    if ( src.val().substr( caretStart - 1, 1 ) == '\n' ) {
                        textBefore = src.val().substr( 0, caretStart + 1 );
                    }

                    method.toDiv.call( this, false, textBefore, textAfter );

                    // If you go through the bottom
                    if ( tar.height() > ( src.height() + src.scrollTop() ) ) {
                        vScroll = src.scrollTop() + parseInt( src.css( "line-height" ) );
                    }
                    // if you go through the top
                    else if ( tar.height() <= src.scrollTop() ) {
                        vScroll = src.scrollTop() - parseInt( src.css( "line-height" ) );
                    }						
					
                    // Scroll the px
                    if ( vScroll )
					{
                        method.scrollToPx.call( this,
												vScroll
											);
					}	
                },

                // Check the old and new height if it needs to scroll
                checkScroll: function (key)
                {				
					 // Scroll if needed
                    var src = $( this );
                    var tar = $( this ).next( "." + settings.hiddenTextareaClass );
					
                    // Put into the div to check new height
					var caretStart = src.caret().start;
                    var textBefore = src.val().substr( 0, caretStart );
					var textAfter = src.val().substr(caretStart, src.val().length);
					
					method.toDiv.call( this, true, textBefore, textAfter );
					
					// If your halfway the scroll, then dont scroll
					if( 
					   	(src.scrollTop() + src.height()) > tar.height()
					)
					{
						return;
					}                    
					
                    // Scroll if needed
                    if ( tar.data( "old-height" ) != tar.data( "new-height" ) ) {
                        var scrollDiff = tar.data( "new-height" ) - tar.data( "old-height" );
                        method.scrollToPx.call( this, src.scrollTop() + scrollDiff );
                    }
					
                },

                // Place the value of the textarea into the DIV
                toDiv: function ( setHeight, html, textAfter )
                {
                    var src = $( this );
                    var tar = $( this ).next( "." + settings.hiddenTextareaClass );
                    var regEnter = /\n/g;
                    var regSpace = /\s\s/g;
					var regSingleSpace = /\s/g;
                    var res = src.val();
					var appendEnter = false;
					var appendEnterSpace = false;
                    if ( html )
                        res = html;
					
					// If last key is enter
					// 		or last key is space, and key before that was enter, then add enter
					if( regEnter.test( res.substring(res.length - 1, res.length)) )
					{
						appendEnter = true;	
					}
					
					if(
						 	regEnter.test( res.substring(res.length - 2, res.length - 1)) && 
							regSingleSpace.test(res.substring(res.length - 1, res.length))
						)
					{
						appendEnterSpace = true;
					}
					
                    // Set old and new height + set the content
                    if ( setHeight )
                        tar.data( "old-height", tar.height() );
						
					res = res.replace( regEnter, "<br>" );// No space or it will be replaced by the function below
                    res = res.replace( regSpace, "&nbsp; " );
                    res = res.replace( regSpace, "&nbsp; " ); // 2x because 1x can result in: &nbsp;(space)(space) and that is not seen within the div
					res = res.replace(/<br>/ig,'<br />');
                    tar.html( res );

					if( ( appendEnter || appendEnterSpace ) && $.trim(textAfter) == "")
					{
						if( appendEnterSpace && $.browser.msie )
							tar.append("<br />");							
						tar.append("<br />");
					}
						
                    if ( setHeight )
					{
                        tar.data( "new-height", tar.height() );
					}
                },

                // Scroll to a given percentage
                scrollToPercentage: function ( perc )
                {
                    // Between 0 and 100
                    if ( perc < 0 || perc > 100 )
                        return this;

                    var src = $( this );
                    var tar = $( this ).next( "." + settings.hiddenTextareaClass );

                    var maxScroll = parseFloat(src[0].scrollHeight) - src.height();
                    var scrollT = maxScroll * perc / 100;

                    // Round on a row
                    method.scrollToPx.call( this, scrollT );
                },

                // Scroll to given PX
                scrollToPx: function ( px )
                {
                    // Round on a row
					px = method.roundToLineHeight.call( this, px );
                    $( this ).scrollTop(  px );
					
					method.scrollCallBack.call(this);					
                },
		
                // Round to line height
                roundToLineHeight: function ( num )
                {
                    return Math.ceil( num / parseInt( $(this).css( "line-height" ) ) ) * parseInt( $(this).css( "line-height" ) );
                },

                // Reset to default
                remove: function ()
                {
                    $( this )
						.unbind( "keyup" )
						.css( {
						    overflow: "auto",
						    border: ""
						} )
					.next("div")
						.remove();
                },
				scrollCallBack : function()
				{
					var maxScroll = parseFloat($(this)[0].scrollHeight) - $(this).height();
					var percentage = (parseFloat($(this)[0].scrollTop) / maxScroll * 100);
					percentage = percentage > 100 ? 100 : percentage;
					percentage = percentage < 0 ? 0 : percentage;
					percentage = isNaN(percentage) ? 100 : percentage;
					$(this).trigger("scrollToPx", [$(this)[0].scrollTop, percentage]);	
				}
            };

            if ( typeof ( options ) == "string" ) {
                method[options].call( this, arg1 );
                return this;
            }
            return this.each( function ()
            {
                if ( !$( this ).next().hasClass( settings.hiddenTextareaClass ) ) {
                    method.init.call( this );
                    method.toDiv.call( this, true );
                }
            } );
        }
    } );

} )( jQuery );