IF OBJECT_ID(N'[Money].[FK__Money__Transactions__Creditor]', 'F') IS NULL
BEGIN
	ALTER TABLE [Money].[Transactions]  WITH CHECK 
	ADD CONSTRAINT [FK__Money__Transactions__Creditor] 
	FOREIGN KEY([Creditor]) 
	REFERENCES [Houses].[Users] ([UserId]) 
END
GO
