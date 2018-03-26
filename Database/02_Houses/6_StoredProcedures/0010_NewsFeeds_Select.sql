CREATE OR ALTER PROCEDURE [Houses].[NewsFeeds_Select]
AS
BEGIN
	SELECT
		NewsFeed.NewsFeedId
		, NewsFeed.Headline
		, NewsFeed.SubHeadline
		, NewsFeed.Story
		, NewsFeed.Author
	FROM Houses.NewsFeed as NewsFeed
END
GO
