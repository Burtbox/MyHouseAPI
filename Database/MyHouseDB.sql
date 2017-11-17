/*
-- File Name: IF SCHEMA_ID(N'Diagnostics') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	EXEC sys.sp_executesql N'CREATE SCHEMA [Diagnostics]' 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Diagnostics].[Logs]', 'U') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	CREATE TABLE [Diagnostics].[Logs] ( 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [Id] int IDENTITY(1,1) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [Message] nvarchar(max) NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [MessageTemplate] nvarchar(max) NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [Level] nvarchar(128) NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [TimeStamp] datetimeoffset(7) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [Exception] nvarchar(max) NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [Properties] xml NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   [LogEvent] nvarchar(max) NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	   CONSTRAINT [PK__Diagnostics__Logs]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		 PRIMARY KEY CLUSTERED ([Id] ASC)  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 			   ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		 ON [PRIMARY] 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	) ON [PRIMARY] 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF SCHEMA_ID(N'Houses') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	EXEC sys.sp_executesql N'CREATE SCHEMA [Houses]' 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[Households]', N'U') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	CREATE TABLE [Houses].[Households]( 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[HouseholdId] [int] IDENTITY(1,1) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[Name] [nvarchar](50) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[EnteredBy] [nvarchar](36) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[EnteredDate] [datetime] NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[ModifiedBy] [nvarchar](36) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[ModifiedDate] [datetime] NOT NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	 CONSTRAINT [PK__Houses__Households] PRIMARY KEY CLUSTERED  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	( 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[HouseholdId] ASC 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	) ON [PRIMARY] 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[DF__Money__Households__ModifiedDate]', N'D') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	ALTER TABLE [Houses].[Households]   
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	ADD CONSTRAINT DF__Money__Households__ModifiedDate  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	DEFAULT GETUTCDATE()  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	FOR ModifiedDate 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[Occupants]', 'U') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	CREATE TABLE [Houses].[Occupants]( 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[OccupantId] [int] IDENTITY(1,1) NOT null, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[UserId] [nvarchar](36) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[DisplayName] [varchar](100) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[HouseholdId] [int] NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[EnteredBy] [nvarchar](36) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[EnteredDate] [datetime] NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[ModifiedBy] [nvarchar](36) NOT NULL, 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[ModifiedDate] [datetime] NOT NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	 CONSTRAINT [PK__Houses__Occupants] PRIMARY KEY CLUSTERED  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	( 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		[OccupantId] ASC 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	) ON [PRIMARY] 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[DF__Money__Occupants__ModifiedDate]', N'D') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	ALTER TABLE [Houses].[Occupants]   
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	ADD CONSTRAINT DF__Money__Occupants__ModifiedDate  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	DEFAULT GETUTCDATE()  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	FOR ModifiedDate 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[FK__Houses__Occupants__HouseholdId]', 'F') IS NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	ALTER TABLE [Houses].[Occupants]  WITH CHECK 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	ADD  CONSTRAINT [FK__Houses__Occupants__HouseholdId]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	FOREIGN KEY([HouseholdId]) 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	REFERENCES [Houses].[Households] ([HouseholdId]) 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[Households_Of_Occupant]', 'P') IS NOT NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	DROP PROCEDURE [Houses].[Households_Of_Occupant]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: CREATE PROCEDURE [Houses].[Households_Of_Occupant]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: @UserId AS INT 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: AS 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	SELECT  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		Households.HouseholdId 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 		, Households.Name  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	FROM Houses.Occupants 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	INNER JOIN Houses.Households ON Houses.Occupants.HouseholdId = Houses.Households.HouseholdId 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	WHERE UserId = @UserId 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[Households_Insert]', 'P') IS NOT NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	DROP PROCEDURE [Houses].[Households_Insert]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: CREATE PROCEDURE [Houses].[Households_Insert]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: @Name AS NVARCHAR(50) 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: AS 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	INSERT INTO [Houses].Households (Name) 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	VALUES (@Name) 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[Households_Update]', 'P') IS NOT NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	DROP PROCEDURE [Houses].[Households_Update]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: CREATE PROCEDURE [Houses].[Households_Update]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: @HouseholdId AS INT 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: , @Name AS NVARCHAR(50) 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: AS 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	UPDATE Houses.Households  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	SET Name = @Name  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	WHERE HouseholdId = @HouseholdId 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: IF OBJECT_ID(N'[Houses].[Households_Delete]', 'P') IS NOT NULL 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: BEGIN 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: 	DROP PROCEDURE [Houses].[Households_Delete]  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: END 
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name: GO  
-- First Created: 
-- Last Modified: 
*/
IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO
GO

/*
-- File Name:  
