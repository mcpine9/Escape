using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Tweetinvi.Core.Interfaces;
using User = Tweetinvi.User;

namespace EscapeMobility.Models
{
    public class TwitterFeedViewModel
    {
        public IEnumerable<ITweet> ListOfTweets { get; set; }
        public string StatusMessage { get; set; }
        private IEnumerable<ITweet> _homeTimeLineTweets;

        public TwitterFeedViewModel()
        {
            ListOfTweets = AccessTweets();
        }

        public IEnumerable<ITweet> AccessTweets()
        {
            try
            {
                var loggedUser = User.GetUserFromScreenName("@Escape_MC_USA");
                _homeTimeLineTweets = loggedUser.GetUserTimeline(10);
            }
            catch (Exception e)
            {
                StatusMessage = e.Message;
            }


            return _homeTimeLineTweets;
        }

    }
}