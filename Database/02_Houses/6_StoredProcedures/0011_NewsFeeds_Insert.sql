CREATE OR ALTER PROCEDURE Houses.NewsFeeds_Insert
	@Headline nvarchar(100),
	@SubHeadline nvarchar(200) = NULL,
	@Story nvarchar(max) ,
	@Author nvarchar(100),
	@Recipient AS NVARCHAR(36) = NULL,
	@EnteredBy AS NVARCHAR(36),
	@OccupantId as int
AS
BEGIN
	INSERT INTO Houses.NewsFeed
		(Headline, SubHeadline, Story, Author, Recipient, EnteredBy, ModifiedBy)
	OUTPUT
	INSERTED.NewsFeedId,
	INSERTED.Headline,
	INSERTED.SubHeadline,
	INSERTED.Story,
	INSERTED.Author,
	INSERTED.Recipient
	VALUES
		(@Headline, @SubHeadline, @Story, @Author, @Recipient, @EnteredBy, @EnteredBy)
END
GO
