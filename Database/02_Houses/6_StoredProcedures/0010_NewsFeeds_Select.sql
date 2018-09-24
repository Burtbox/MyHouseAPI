CREATE OR ALTER PROCEDURE Houses.NewsFeeds_Select
	@userId NVARCHAR(36)
AS
BEGIN
	SELECT
		NewsFeed.NewsFeedId
		, NewsFeed.Headline
		, NewsFeed.SubHeadline
		, NewsFeed.Story
		, CASE WHEN AuthorDetails.DisplayName IS NOT NULL 
			THEN AuthorDetails.DisplayName 
			ELSE NewsFeed.Author 
		END AS Author
	FROM Houses.NewsFeed AS NewsFeed
		LEFT JOIN Houses.Occupants AS AuthorDetails ON AuthorDetails.UserId = NewsFeed.Author
	Where NewsFeed.Recipient = @userId
		OR NewsFeed.Recipient = 'All'
	ORDER BY NewsFeed.ModifiedDate desc
END
GO