using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialDataFeed.Models.SocialMedia.Facebook
{
    public class FacebookClient : SocialMediaClient
    {
        public string FeedUrl { get; set; } =
            "me?fields=id,name,feed.limit(1000){message,story,created_time,attachments{description,type,url,title,media,target},likes{id,name},comments{id,from,message}}";

        public FacebookClient()
        {
            ProviderKey = "facebook";
            baseUrl = "https://graph.facebook.com/";
        }

        public async Task<posts> Posts()
        {
            //Access Token
            await GetAccessToken();

            string url = String.Format("{0}{1}&access_token={2}", baseUrl, FeedUrl, AccessToken);

            //Get data
            dynamic jsonObj = await Get(url);

            //Convert JSON
            Models.SocialMedia.Facebook.posts posts =
                new Models.SocialMedia.Facebook.posts(jsonObj);
            return (posts);
        }

    }
}