namespace MyHouseAPI.Model.Houses
{
    public abstract class NewsFeedDetails
    {
        public string Headline { get; set; }
        public string SubHeadline { get; set; }
        public string Story { get; set; }
        public string Author { get; set; }
    }

    public abstract class NewsFeed : NewsFeedDetails
    {
        public int NewsFeedId { get; set; }
    }

    public class NewsFeedResponse : NewsFeed { }


    public class NewsFeedInsertRequest : NewsFeedDetails
    {
        public string EnteredBy { get; set; }
    }

    public class NewsFeedUpdateRequest : NewsFeedDetails { }
}
