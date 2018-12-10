using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace TweetCloneApp.ViewModel
{
    public class TweetViewModel
    {
        public tweet objTweet { get; set; }

        public List<tweet> objTweetList { get; set; }
        
        public string tweetCount { get; set; }

        public string followersCount { get; set; }

        public string followingCount { get; set; }

        public List<following> objFollows { get; set; }

        public following objFollow { get; set; }

    }
}