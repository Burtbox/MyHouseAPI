IF OBJECT_ID(N'[Food].[FK__Food__Attendees__Date]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Attendees]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Attendees__Date] 
	FOREIGN KEY([Date])
	REFERENCES [Food].[Days] ([Date])
END
GO