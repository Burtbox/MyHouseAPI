IF OBJECT_ID(N'Food.Attendees', N'U') IS NULL
BEGIN
	CREATE TABLE Food.Attendees
	(
		AttendeeId int IDENTITY(1,1) NOT NULL,
		Date date NOT NULL,
		Name nvarchar(100) NOT NULL,
		CONSTRAINT PK__Food__Attendees PRIMARY KEY CLUSTERED 
	(
		AttendeeId ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	)
END
GO
