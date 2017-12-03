IF OBJECT_ID(N'[Money].[Transactions]', N'U') IS NULL
BEGIN
	CREATE TABLE [Money].[Transactions]
	(
		[TransactionId] [int] IDENTITY(1,1) NOT NULL,
		[Creditor] [int] NOT NULL,
		[Debtor] [int] NOT NULL,
		[Gross] [decimal](18, 2) NOT NULL,
		[Reference] [nvarchar](200) NULL,
		[Date] [date] NULL,
		[EnteredBy] [int] NOT NULL,
		[EnteredDate] [datetime] NOT NULL,
		[ModifiedBy] [nvarchar](36) NOT NULL,
		[ModifiedDate] [datetime] NOT NULL
			CONSTRAINT [PK__Money__Transactions] PRIMARY KEY CLUSTERED 
	(
		[TransactionId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF OBJECT_ID(N'[Money].[DF__Money__Transactions__EnteredDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Money].[Transactions]  
	ADD CONSTRAINT DF__Money__Transactions__EnteredDate 
	DEFAULT GETUTCDATE() 
	FOR EnteredDate
END
GO

IF OBJECT_ID(N'[Money].[DF__Money__Transactions__ModifiedDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Money].[Transactions]  
	ADD CONSTRAINT DF__Money__Transactions__ModifiedDate 
	DEFAULT GETUTCDATE() 
	FOR ModifiedDate
END
GO
