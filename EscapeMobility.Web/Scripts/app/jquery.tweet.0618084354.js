//jtwt.js by Harbor (http://jtwt.hrbor.com)

(function ($) {

    $.fn.jtwt = function (options) {

        //Declare defaults
        var defaults = {
            username: 'harbor',
            query: '',
            count: 4,
            image_size: 48,
            convert_links: true,
            loader_text: 'loading new tweets',
            no_result: 'No recent tweets found'

        }

        //Merge default with options
        var options = $.extend(defaults, options);

        // customized parseTwitterDate. Base by http://stackoverflow.com/users/367154/brady - Special thanks to @mikloshenrich
        function parseTwitterDate(time_value) {
            var values = time_value.split(" ");
            time_value = values[1] + " " + values[2] + ", " + values[5] + " " + values[3];
            var parsed_date = Date.parse(time_value);
            var relative_to = (arguments.length > 1) ? arguments[1] : new Date();
            var delta = parseInt((relative_to.getTime() - parsed_date) / 1000);
            delta = delta + (relative_to.getTimezoneOffset() * 60);

            if (delta < 60) {
                return 'less than a minute ago';
            } else if (delta < 120) {
                return 'about a minute ago';
            } else if (delta < (60 * 60)) {
                return (parseInt(delta / 60)).toString() + ' minutes ago';
            } else if (delta < (120 * 60)) {
                return 'about an hour ago';
            } else if (delta < (24 * 60 * 60)) {
                return 'about ' + (parseInt(delta / 3600)).toString() + ' hours ago';
            } else if (delta < (48 * 60 * 60)) {
                return '1 day ago';
            } else {
                return (parseInt(delta / 86400)).toString() + ' days ago';
            }
        }

        return this.each(function () {

            var o = options;
            var obj = $(this);
            var q;

            $(obj).append('<ul class="jtwt"></ul>');
            $(".jtwt", obj).append('<li class="jtwt_loader jtwt_tweet" style="display:none;">' + o.loader_text + '</li>');
            $(".jtwt_loader", obj).fadeIn('slow');

            //Check if there is a search query given, if not fetch user tweets
            if (o.query) {

                q = encodeURIComponent(o.query);

            } else {

                q = 'from:' + encodeURIComponent(o.username);

            }

            //get the tweets from the API
            $.ajax({
                type: "GET",
                url: '/twitter.aspx',
                data: {
                    username: o.username
                },
                dataType: "json",
                success: function (data) {
                    var results = data,
                        twitters = results;

                    if (results.length) {

                        var statusHTML = [];
                        for (var i = 0; i < twitters.length; i++) {
                            var username = twitters[i].user.screen_name;
                            var status = twitters[i].text.replace(/((https?|s?ftp|ssh)\:\/\/[^"\s\<\>]*[^.,;'">\:\s\<\>\)\]\!])/g, function (url) {
                                return '<a href="' + url + '">' + url + '</a>';
                            }).replace(/\B@([_a-z0-9]+)/ig, function (reply) {
                                return reply.charAt(0) + '<a href="http://twitter.com/' + reply.substring(1) + '">' + reply.substring(1) + '</a>';
                            });
                            statusHTML.push('<li><span>' + status + '</span> <a style="font-size:85%" href="http://twitter.com/' + username + '/statuses/' + twitters[i].id_str + '">' + parseTwitterDate(twitters[i].created_at) + '</a></li>');
                        }
                        $(".jtwt", obj).append(statusHTML.join(''));

                    } else {

                        //If there are not any tweets, display the "no results" container
                        $(".jtwt_loader", obj).fadeOut('fast', function () {

                            $(".jtwt", obj).append('<li class="jtwt_noresult jtwt_tweet" style="display:none;">' + o.no_result + '</li>');
                            $(".jtwt_noresult", obj).fadeIn('slow');

                        });


                    }

                    $(".jtwt_loader", obj).fadeOut('fast');
                }
            });

        });

    }

})(jQuery);