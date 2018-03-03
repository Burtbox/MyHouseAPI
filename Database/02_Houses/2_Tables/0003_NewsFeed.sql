IF OBJECT_ID(N'[Houses].[NewsFeed]', N'U') IS NULL
BEGIN
	CREATE TABLE [Houses].[NewsFeed]
	(
		[NewsId] [int] IDENTITY(1,1) NOT NULL,
		[HouseholdId] [int] NOT NULL,
		[Headline] [nvarchar](100) NOT NULL,
		[SubHeadline] [nvarchar](200) NULL,
		[Story] [nvarchar](max) NOT NULL,
		[Author] [nvarchar](100) NOT NULL,
		[EnteredBy] [nvarchar](36) NOT NULL,
		[EnteredDate] [datetime] NOT NULL,
		[ModifiedBy] [nvarchar](36) NOT NULL,
		[ModifiedDate] [datetime] NOT NULL
			CONSTRAINT [PK__Houses__NewsFeed] PRIMARY KEY CLUSTERED 
	(
		[NewsId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF OBJECT_ID(N'[Houses].[DF__Houses__NewsFeed__EnteredDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Houses].[NewsFeed]  
	ADD CONSTRAINT DF__Houses__NewsFeed__EnteredDate 
	DEFAULT GETUTCDATE() 
	FOR EnteredDate
END
GO

IF OBJECT_ID(N'[Houses].[DF__Houses__NewsFeed__ModifiedDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Houses].[NewsFeed]  
	ADD CONSTRAINT DF__Houses__NewsFeed__ModifiedDate 
	DEFAULT GETUTCDATE() 
	FOR ModifiedDate
END
GO