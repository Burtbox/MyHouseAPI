CREATE OR ALTER PROCEDURE [Houses].[NewsFeeds_Get]
	@UserId AS INT
AS
SELECT
	NewsFeed.NewsId
	, NewsFeed.HouseholdId
	, NewsFeed.Headline
	, NewsFeed.SubHeadline
	, NewsFeed.Story
	, NewsFeed.Author
FROM Houses.NewsFeed as NewsFeed
INNER JOIN Houses.Occupants as Occupants ON Occupants.HouseholdId = NewsFeed.HouseholdId
WHERE UserId = @UserId

GO
