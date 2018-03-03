IF OBJECT_ID(N'[Houses].[FK__Houses__NewsFeed__HouseholdId]', 'F') IS NULL
BEGIN
	ALTER TABLE [Houses].[NewsFeed]  WITH CHECK
	ADD  CONSTRAINT [FK__Houses__NewsFeed__HouseholdId] 
	FOREIGN KEY([HouseholdId])
	REFERENCES [Houses].[Households] ([HouseholdId])
END
GO
