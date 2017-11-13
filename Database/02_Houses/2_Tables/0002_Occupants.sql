IF OBJECT_ID(N'[Houses].[Occupants]', 'U') IS NULL
BEGIN
	CREATE TABLE [Houses].[Occupants](
		[OccupantId] [int] IDENTITY(1,1) NOT null,
		[UserId] [nvarchar](36) NOT NULL,
		[DisplayName] [varchar](100) NOT NULL,
		[HouseholdId] [int] NOT NULL,
	 CONSTRAINT [PK__Houses__Occupants] PRIMARY KEY CLUSTERED 
	(
		[OccupantId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
