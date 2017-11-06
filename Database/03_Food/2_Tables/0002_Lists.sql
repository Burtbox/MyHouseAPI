IF OBJECT_ID(N'[Food].[Lists]', N'U') IS NULL
BEGIN
	CREATE TABLE [Food].[Lists](
		[ListId] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](200) NOT NULL,
		[DateCreated] [datetime] NULL,
		[Complete] [bit] NOT NULL,
		[DateCompleted] [datetime] NULL,
	 CONSTRAINT [PK__Food__Lists] PRIMARY KEY CLUSTERED 
	(
		[ListId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF OBJECT_ID(N'[Food].[DF__Food__Lists__Complete]', N'D') IS NULL
BEGIN
	ALTER TABLE [Food].[Lists] ADD CONSTRAINT [DF__Food__Lists__Complete]  DEFAULT ((0)) FOR [Complete]
END
GO
