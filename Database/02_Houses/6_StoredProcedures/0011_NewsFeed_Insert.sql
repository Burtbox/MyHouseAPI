CREATE OR ALTER PROCEDURE Houses.NewsFeeds_Insert
	@HouseholdId int,
	@Headline nvarchar(100),
	@SubHeadline nvarchar(200) = NULL,
	@Story nvarchar(max) ,
	@Author nvarchar(100),
	@EnteredBy AS NVARCHAR(36)
AS
BEGIN
	INSERT INTO Houses.NewsFeed
		(HouseholdId, Headline, SubHeadline, Story, Author, EnteredBy, ModifiedBy)
	OUTPUT
	INSERTED.NewsId, INSERTED.HouseholdId, INSERTED.Headline, INSERTED.SubHeadline, INSERTED.Story, INSERTED.Author
	VALUES
		(@HouseholdId, @Headline, @SubHeadline, @Story, @Author, @EnteredBy, @EnteredBy)
END
GO
