IF OBJECT_ID(N'Houses.NewsFeed', N'U') IS NULL
BEGIN
	CREATE TABLE Houses.NewsFeed
	(
		NewsFeedId int IDENTITY(1,1) NOT NULL,
		Headline nvarchar(100) NOT NULL,
		SubHeadline nvarchar(200) NULL,
		Story nvarchar(max) NOT NULL,
		Author nvarchar(100) NOT NULL,
		EnteredBy nvarchar(36) NOT NULL,
		EnteredDate DATETIME2(3) NOT NULL,
		ModifiedBy nvarchar(36) NOT NULL,
		ModifiedDate DATETIME2(3) NOT NULL,
		Recipient nvarchar(36) NULL
			CONSTRAINT PK__Houses__NewsFeed PRIMARY KEY CLUSTERED 
	(
		NewsFeedId ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	)
END
GO

IF OBJECT_ID(N'Houses.DF__Houses__NewsFeed__EnteredDate', N'D') IS NULL
BEGIN
	ALTER TABLE Houses.NewsFeed  
	ADD CONSTRAINT DF__Houses__NewsFeed__EnteredDate 
	DEFAULT GETUTCDATE() 
	FOR EnteredDate
END
GO

IF OBJECT_ID(N'Houses.DF__Houses__NewsFeed__ModifiedDate', N'D') IS NULL
BEGIN
	ALTER TABLE Houses.NewsFeed  
	ADD CONSTRAINT DF__Houses__NewsFeed__ModifiedDate 
	DEFAULT GETUTCDATE() 
	FOR ModifiedDate
END
GO
