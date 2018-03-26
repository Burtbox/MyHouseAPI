CREATE OR ALTER PROCEDURE Houses.NewsFeeds_Insert
	@Headline nvarchar(100),
	@SubHeadline nvarchar(200) = NULL,
	@Story nvarchar(max) ,
	@Author nvarchar(100),
	@EnteredBy AS NVARCHAR(36)
AS
BEGIN
	INSERT INTO Houses.NewsFeed
		(Headline, SubHeadline, Story, Author, EnteredBy, ModifiedBy)
	OUTPUT
	INSERTED.NewsFeedId,
	INSERTED.Headline,
	INSERTED.SubHeadline,
	INSERTED.Story,
	INSERTED.Author
	VALUES
		(@Headline, @SubHeadline, @Story, @Author, @EnteredBy, @EnteredBy)
END
GO
