IF OBJECT_ID(N'Houses.Occupants', 'U') IS NULL
BEGIN
	CREATE TABLE Houses.Occupants
	(
		OccupantId int IDENTITY(1,1) NOT null,
		UserId nvarchar(36) NOT NULL,
		DisplayName varchar(100) NOT NULL,
		HouseholdId int NOT NULL,
		EnteredBy nvarchar(36) NOT NULL,
		EnteredDate DATETIME2(3) NOT NULL,
		ModifiedBy nvarchar(36) NOT NULL,
		ModifiedDate DATETIME2(3) NOT NULL
			CONSTRAINT PK__Houses__Occupants PRIMARY KEY CLUSTERED 
	(
		OccupantId ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	)
END
GO

IF OBJECT_ID(N'Houses.DF__Money__Occupants__EnteredDate', N'D') IS NULL
BEGIN
	ALTER TABLE Houses.Occupants  
	ADD CONSTRAINT DF__Money__Occupants__EnteredDate 
	DEFAULT GETUTCDATE() 
	FOR EnteredDate
END
GO

IF OBJECT_ID(N'Houses.DF__Money__Occupants__ModifiedDate', N'D') IS NULL
BEGIN
	ALTER TABLE Houses.Occupants  
	ADD CONSTRAINT DF__Money__Occupants__ModifiedDate 
	DEFAULT GETUTCDATE() 
	FOR ModifiedDate
END
GO
