IF OBJECT_ID(N'[Houses].[Households]', N'U') IS NULL
BEGIN
	CREATE TABLE [Houses].[Households]
	(
		[HouseholdId] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[EnteredBy] [nvarchar](36) NOT NULL,
		[EnteredDate] [datetime] NOT NULL,
		[ModifiedBy] [nvarchar](36) NOT NULL,
		[ModifiedDate] [datetime] NOT NULL
			CONSTRAINT [PK__Houses__Households] PRIMARY KEY CLUSTERED 
	(
		[HouseholdId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END
GO

IF OBJECT_ID(N'[Houses].[DF__Money__Households__EnteredDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Houses].[Households]  
	ADD CONSTRAINT DF__Money__Households__EnteredDate 
	DEFAULT GETUTCDATE() 
	FOR EnteredDate
END
GO

IF OBJECT_ID(N'[Houses].[DF__Money__Households__ModifiedDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Houses].[Households]  
	ADD CONSTRAINT DF__Money__Households__ModifiedDate 
	DEFAULT GETUTCDATE() 
	FOR ModifiedDate
END
GO
