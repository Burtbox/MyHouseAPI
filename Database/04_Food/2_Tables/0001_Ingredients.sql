IF OBJECT_ID(N'[Food].[Ingredients]', N'U') IS NULL
BEGIN
	CREATE TABLE [Food].[Ingredients](
		[IngredientId] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](200) NOT NULL,
		[Units] [nvarchar](20) NOT NULL,
	 CONSTRAINT [PK__Food__Ingredients] PRIMARY KEY CLUSTERED 
	(
		[IngredientId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO