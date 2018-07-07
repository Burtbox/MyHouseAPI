CREATE OR ALTER PROCEDURE Houses.NewsFeeds_Select
	@userId NVARCHAR(36)
AS
BEGIN
	SELECT
		NewsFeed.NewsFeedId
		, NewsFeed.Headline
		, NewsFeed.SubHeadline
		, NewsFeed.Story
		, NewsFeed.Author
	FROM Houses.NewsFeed as NewsFeed
	Where NewsFeed.Recipient = @userId 
		OR NewsFeed.Recipient = 'All'
END
GO
