IF OBJECT_ID(N'[Houses].[FK__Houses__Users__HouseholdId]', 'F') IS NULL
BEGIN
	ALTER TABLE [Houses].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Houses__Users__HouseholdId] FOREIGN KEY([HouseholdId])
	REFERENCES [Houses].[Households] ([HouseholdId])

	ALTER TABLE [Houses].[Users] CHECK CONSTRAINT [FK__Houses__Users__HouseholdId]
END
GO
