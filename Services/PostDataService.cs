using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Brief_for_Reddit.Models;
using System;

namespace Brief_for_Reddit.Services
{
    class PostDataService
    {
        public static async Task<(List<Post>, string)> GetPosts(int count, string after)
        {
            Console.WriteLine($"ABCDE got parameter {after}");
            List<Post> posts = new List<Post>();

            var network = new NetworkAccessService();
            string info = await network.RedditWebRequest(after);
            var json = JObject.Parse(info);

            after = json["data"]["after"].ToString();

            for (int i = 0; i < count; i++)
            {
                var item = json["data"]["children"][i]["data"];
                Post post = new Post();
                post.Title = item["title"].ToString();
                post.ShortTitle = post.Title.Length <= 45 ? post.Title : post.Title.Substring(0, 45) + "...";
                post.ContentUrl = item["url"].ToString();
                post.Subreddit = item["subreddit_name_prefixed"].ToString();
                var postHint = item["post_hint"];
                if (postHint != null)
                {
                    post.PostHint = postHint.ToString();
                    posts.Add(post);
                }

            }

            Console.WriteLine($"ABCDE returning parameter {after}");
            return (posts, after);
        }
    }
}
