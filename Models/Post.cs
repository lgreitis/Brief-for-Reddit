namespace Brief_for_Reddit.Models
{
    public class Post
    {
        public string Title { get; set; }

        public string Subreddit { get; set; }

        public string ContentUrl { get; set; }

        public string PostHint { get; set; }

        public string ShortTitle { get; set; }

        public Post(string title, string subreddit, string contentUrl, string postHint)
        {
            this.Title = title;
            this.Subreddit = subreddit;
            this.ContentUrl = contentUrl;
            this.PostHint = postHint;
        }

        public Post()
        {
        }

        public override string ToString()
        {
            return "TODO";
        }
    }
}
