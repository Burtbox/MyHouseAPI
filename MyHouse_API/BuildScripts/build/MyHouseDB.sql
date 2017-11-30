/*
-- File Name: 0001_ReadCommitted.sql 
-- First Created: 17/11/2017 13:57:31
-- Last Modified: 17/11/2017 13:57:48
*/
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Diagnostics.sql 
-- First Created: 13/11/2017 18:10:31
-- Last Modified: 13/11/2017 18:18:32
*/
IF SCHEMA_ID(N'Diagnostics') IS NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Diagnostics]'
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Houses.sql 
-- First Created: 06/11/2017 19:35:30
-- Last Modified: 13/11/2017 18:18:58
*/
IF SCHEMA_ID(N'Houses') IS NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Houses]'
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Households.sql 
-- First Created: 06/11/2017 19:47:16
-- Last Modified: 17/11/2017 13:36:42
*/
IF OBJECT_ID(N'[Houses].[Households]', N'U') IS NULL
BEGIN
	CREATE TABLE [Houses].[Households](
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
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0002_Occupants.sql 
-- First Created: 06/11/2017 20:17:58
-- Last Modified: 17/11/2017 13:38:20
*/
IF OBJECT_ID(N'[Houses].[Occupants]', 'U') IS NULL
BEGIN
	CREATE TABLE [Houses].[Occupants](
		[OccupantId] [int] IDENTITY(1,1) NOT null,
		[UserId] [nvarchar](36) NOT NULL,
		[DisplayName] [varchar](100) NOT NULL,
		[HouseholdId] [int] NOT NULL,
		[EnteredBy] [nvarchar](36) NOT NULL,
		[EnteredDate] [datetime] NOT NULL,
		[ModifiedBy] [nvarchar](36) NOT NULL,
		[ModifiedDate] [datetime] NOT NULL
	 CONSTRAINT [PK__Houses__Occupants] PRIMARY KEY CLUSTERED 
	(
		[OccupantId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF OBJECT_ID(N'[Houses].[DF__Money__Occupants__EnteredDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Houses].[Occupants]  
	ADD CONSTRAINT DF__Money__Occupants__EnteredDate 
	DEFAULT GETUTCDATE() 
	FOR EnteredDate
END
GO

IF OBJECT_ID(N'[Houses].[DF__Money__Occupants__ModifiedDate]', N'D') IS NULL
BEGIN
	ALTER TABLE [Houses].[Occupants]  
	ADD CONSTRAINT DF__Money__Occupants__ModifiedDate 
	DEFAULT GETUTCDATE() 
	FOR ModifiedDate
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Houses_Occupants_HouseholdId.sql 
-- First Created: 06/11/2017 19:52:40
-- Last Modified: 06/11/2017 20:31:29
*/
IF OBJECT_ID(N'[Houses].[FK__Houses__Occupants__HouseholdId]', 'F') IS NULL
BEGIN
	ALTER TABLE [Houses].[Occupants]  WITH CHECK
	ADD  CONSTRAINT [FK__Houses__Occupants__HouseholdId] 
	FOREIGN KEY([HouseholdId])
	REFERENCES [Houses].[Households] ([HouseholdId])
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Households_Of_Occupant_Select.sql 
-- First Created: 06/11/2017 21:08:16
-- Last Modified: 17/11/2017 12:16:34
*/
CREATE OR ALTER PROCEDURE [Houses].[Households_Of_Occupant] 
@UserId AS INT
AS
	SELECT 
		Households.HouseholdId
		, Households.Name 
	FROM Houses.Occupants
	INNER JOIN Houses.Households ON Houses.Occupants.HouseholdId = Houses.Households.HouseholdId
	WHERE UserId = @UserId

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0002_Households_Insert.sql 
-- First Created: 06/11/2017 20:43:11
-- Last Modified: 17/11/2017 13:34:42
*/
CREATE OR ALTER PROCEDURE [Houses].[Households_Insert] 
@Name AS NVARCHAR(50),
@EnteredBy AS NVARCHAR(50)

AS
	INSERT INTO [Houses].Households (Name, EnteredBy, ModifiedBy)
	VALUES (@Name, @EnteredBy, @EnteredBy)

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0003_Households_Update.sql 
-- First Created: 06/11/2017 20:43:48
-- Last Modified: 17/11/2017 12:19:03
*/
CREATE OR ALTER PROCEDURE [Houses].[Households_Update] 
@HouseholdId AS INT
, @Name AS NVARCHAR(50)

AS
	UPDATE Houses.Households 
	SET Name = @Name 
	WHERE HouseholdId = @HouseholdId
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0004_Households_Delete.sql 
-- First Created: 06/11/2017 20:44:03
-- Last Modified: 17/11/2017 12:18:57
*/
CREATE OR ALTER PROCEDURE [Houses].[Households_Delete] 
@HouseholdId AS INT

AS
	DELETE FROM HOUSEHOLDS 
	WHERE HouseholdId = @HouseholdId
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0005_Occupants_Of_Household_Select.sql 
-- First Created: 06/11/2017 21:09:53
-- Last Modified: 17/11/2017 13:45:15
*/
CREATE OR ALTER PROCEDURE [Houses].[Occupants_Of_Household] 
@HouseholdId AS INT
AS
	SELECT 
		OccupantId 
		, UserId
		, DisplayName 
		, HouseholdId
	FROM Houses.Occupants
	WHERE HouseholdId = @HouseholdId

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0006_Occupants_Insert.sql 
-- First Created: 06/11/2017 20:50:19
-- Last Modified: 18/11/2017 12:44:01
*/
CREATE OR ALTER PROCEDURE [Houses].[Occupants_Insert] 
@UserId AS NVARCHAR(36)
, @DisplayName AS VARCHAR(100)
, @HouseholdId AS INT

AS
	INSERT INTO Houses.Occupants (UserId, DisplayName, HouseholdId, EnteredBy, ModifiedBy)
	OUTPUT INSERTED.OccupantId, INSERTED.UserId, INSERTED.DisplayName, INSERTED.HouseholdId
	VALUES (@UserId, @DisplayName, @HouseholdId, @UserId, @UserId)

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0007_Occupants_Update.sql 
-- First Created: 06/11/2017 20:51:05
-- Last Modified: 17/11/2017 14:03:12
*/
CREATE OR ALTER PROCEDURE [Houses].[Occupants_Update]
@UserId AS NVARCHAR(36)
, @DisplayName AS VARCHAR(100)
, @OccupantId AS INT
, @HouseholdId AS INT

AS
	UPDATE Houses.Occupants 
	SET DisplayName = @DisplayName
	, ModifiedBy = @OccupantId
	, ModifiedDate = GETUTCDATE()
	WHERE UserId = @UserId -- This will update their display name for all households
	
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0008_Occupants_Delete.sql 
-- First Created: 06/11/2017 20:51:05
-- Last Modified: 17/11/2017 12:18:22
*/
CREATE OR ALTER PROCEDURE [Houses].[Occupants_Delete] 
@OccupantId AS INT
AS
	DELETE FROM Houses.Occupants 
	WHERE OccupantId = @OccupantId

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Money.sql 
-- First Created: 06/11/2017 19:37:55
-- Last Modified: 13/11/2017 18:19:14
*/
IF SCHEMA_ID(N'Money') IS NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Money]'
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Transactions.sql 
-- First Created: 06/11/2017 20:36:36
-- Last Modified: 17/11/2017 10:42:54
*/
IF OBJECT_ID(N'[Money].[Transactions]', N'U') IS NULL
BEGIN
	CREATE TABLE [Money].[Transactions](
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
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Money_Transactions_EnteredBy.sql 
-- First Created: 06/11/2017 20:00:19
-- Last Modified: 06/11/2017 20:36:58
*/
IF OBJECT_ID(N'[Money].[FK__Money__Transactions__EnteredBy]', 'F') IS NULL
BEGIN
	ALTER TABLE [Money].[Transactions]  WITH CHECK 
	ADD CONSTRAINT [FK__Money__Transactions__EnteredBy] 
	FOREIGN KEY([EnteredBy])
	REFERENCES [Houses].[Occupants] ([OccupantId])
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0002_Money_Transactions_Creditor.sql 
-- First Created: 06/11/2017 19:56:45
-- Last Modified: 06/11/2017 20:39:46
*/
IF OBJECT_ID(N'[Money].[FK__Money__Transactions__Creditor]', 'F') IS NULL
BEGIN
	ALTER TABLE [Money].[Transactions]  WITH CHECK 
	ADD CONSTRAINT [FK__Money__Transactions__Creditor] 
	FOREIGN KEY([Creditor]) 
	REFERENCES [Houses].[Occupants] ([OccupantId])
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0003_Money_Transactions_Debtor.sql 
-- First Created: 06/11/2017 20:00:18
-- Last Modified: 06/11/2017 20:39:55
*/
IF OBJECT_ID(N'[Money].[FK__Money__Transactions__Debtor]', 'F') IS NULL
BEGIN
	ALTER TABLE [Money].[Transactions]  WITH CHECK 
	ADD CONSTRAINT [FK__Money__Transactions__Debtor] 
	FOREIGN KEY([Debtor])
	REFERENCES [Houses].[Occupants] ([OccupantId])
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Transaction_History.sql 
-- First Created: 06/11/2017 21:42:07
-- Last Modified: 06/11/2017 21:42:07
*/
IF OBJECT_ID(N'[Money].[TransactionHistory]', N'V') IS NOT NULL 
BEGIN
	DROP VIEW [Money].[TransactionHistory] 
END
GO

CREATE VIEW [Money].[TransactionHistory] 
AS

SELECT 'credit' + CAST(ROW_NUMBER() OVER (ORDER BY [DATE]) AS NVARCHAR(1000)) AS [PRIMARYKEY]
     , Creditor
	 , Debtor
	 , Gross 
	 , Reference 
	 , [Date] 
	 , EnteredBy
	 , EnteredDate
FROM [Money].[Transactions] 

UNION ALL

SELECT 'debt' + CAST(ROW_NUMBER() OVER (ORDER BY [DATE]) AS NVARCHAR(1000)) AS [PRIMARYKEY] 
     , Debtor
	 , Creditor
	 , -Gross AS Gross
	 , Reference 
	 , [Date] 
	 , EnteredBy
	 , EnteredDate
FROM [Money].[Transactions]

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0002_Transaction_Summary.sql 
-- First Created: 06/11/2017 21:33:07
-- Last Modified: 06/11/2017 21:34:40
*/
IF OBJECT_ID(N'[Money].[TransactionSummary]', N'V') IS NOT NULL 
BEGIN
	DROP VIEW [Money].[TransactionSummary] 
END
GO

CREATE VIEW [Money].[TransactionSummary]  
AS

SELECT Positive.DisplayName AS Creditor 
     , Negative.DisplayName AS Debtor 
	 , TotalPositive.Total - TotalNegative.Total AS Gross 
FROM [Houses].[Occupants] AS Positive
CROSS JOIN [Houses].[Occupants] AS Negative
OUTER APPLY (SELECT ISNULL(SUM(GROSS), 0.00) AS Total 
             FROM [Money].[Transactions] 
			 WHERE Creditor = Positive.OccupantId AND Debtor = Negative.OccupantId
            ) AS TotalPositive
OUTER APPLY (SELECT ISNULL(SUM(GROSS), 0.00) AS Total 
             FROM [Money].[Transactions] 
			 WHERE Creditor = Negative.OccupantId AND Debtor = Positive.OccupantId
            ) AS TotalNegative

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0003_Transactions_Insert.sql 
-- First Created: 06/11/2017 21:18:25
-- Last Modified: 17/11/2017 12:18:13
*/
CREATE OR ALTER PROCEDURE [Money].[Transactions_Insert] 
@Creditor AS INT
, @Debtor AS INT
, @Gross AS DECIMAL(18,2)
, @Reference AS VARCHAR(200)
, @Date AS DATE
, @EnteredBy AS INT
AS
	INSERT INTO Transactions (
		Creditor
		, Debtor
		, Gross
		, Reference
		, [Date]
		, EnteredBy
	)
	VALUES (
		@Creditor
		, @Debtor
		, @Gross
		, @Reference
		, @Date
		, @EnteredBy
	)

GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: Food_Schema.sql 
-- First Created: 06/11/2017 19:39:25
-- Last Modified: 13/11/2017 18:19:29
*/
IF SCHEMA_ID(N'Food') IS NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Food]'
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Ingredients.sql 
-- First Created: 06/11/2017 21:44:59
-- Last Modified: 06/11/2017 21:46:32
*/
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
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0002_Lists.sql 
-- First Created: 06/11/2017 21:48:45
-- Last Modified: 06/11/2017 21:49:15
*/
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
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0003_Meals.sql 
-- First Created: 06/11/2017 21:50:47
-- Last Modified: 06/11/2017 22:12:00
*/
IF OBJECT_ID(N'[Food].[Meals]', N'U') IS NULL
BEGIN
	CREATE TABLE [Food].[Meals](
		[MealId] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](200) NOT NULL,
		[Category] [nvarchar](20) NOT NULL,
	 CONSTRAINT [PK__Food__Meals] PRIMARY KEY CLUSTERED 
	(
		[MealId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0004_Attendees.sql 
-- First Created: 06/11/2017 22:09:03
-- Last Modified: 06/11/2017 22:09:03
*/
IF OBJECT_ID(N'[Food].[Attendees]', N'U') IS NULL
BEGIN
	CREATE TABLE [Food].[Attendees](
		[AttendeeId] [int] IDENTITY(1,1) NOT NULL,
		[Date] [date] NOT NULL,
		[Name] [nvarchar](100) NOT NULL,
	 CONSTRAINT [PK__Food__Attendees] PRIMARY KEY CLUSTERED 
	(
		[AttendeeId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0005_Days_GetNumberOfPeople.sql 
-- First Created: 17/11/2017 13:13:02
-- Last Modified: 20/11/2017 13:30:59
*/
IF OBJECT_ID('[Food].[Days_GetNumberOfPeople]') IS NULL
BEGIN
	execute dbo.sp_executesql @statement = N'
	CREATE FUNCTION [Food].[Days_GetNumberOfPeople] (@Date date)
	RETURNS TINYINT
	AS
	BEGIN
		DECLARE @NumberOfPeople TINYINT
		SELECT @NumberOfPeople = COUNT(*)
		FROM [Food].[People]
		WHERE [Date] = @Date
		RETURN @NumberOfPeople
	END'
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0006_Days.sql 
-- First Created: 17/11/2017 12:00:09
-- Last Modified: 20/11/2017 13:30:54
*/
IF OBJECT_ID(N'[Food].[Days]', N'U') IS NULL
BEGIN
	CREATE TABLE [Food].[Days](
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
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0001_Food_Attendees_Date.sql 
-- First Created: 06/11/2017 22:11:45
-- Last Modified: 06/11/2017 22:10:56
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
/*
-- File Name: 0002_Food_Days_MealId.sql 
-- First Created: 17/11/2017 12:02:27
-- Last Modified: 17/11/2017 12:02:59
*/
IF OBJECT_ID(N'[Food].[FK__Food__Days__MealId]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Days]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Days__MealId] 
	FOREIGN KEY([MealId])
	REFERENCES [Food].[Meals] ([MealId])
END
GO
 -- Ending current file --

 GO

 -- Beginning next file --
