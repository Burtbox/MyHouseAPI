IF OBJECT_ID(N'[Food].[Days]', N'U') IS NULL
BEGIN
	CREATE TABLE [Food].[Days]
	(
		[Date] [date] NOT NULL,
		[MealId] [int] NOT NULL,
		[NumberOfPeople]  AS ([Food].[Days_GetNumberOfPeople]([Date])),
		CONSTRAINT [PK__Food__Days] PRIMARY KEY CLUSTERED 
	(
		[Date] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
