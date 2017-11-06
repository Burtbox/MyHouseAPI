IF OBJECT_ID(N'[Money].[FK__Money__Transactions__Debtor]', 'F') IS NULL
BEGIN
	ALTER TABLE [Money].[Transactions]  WITH CHECK 
	ADD CONSTRAINT [FK__Money__Transactions__Debtor] 
	FOREIGN KEY([Debtor])
	REFERENCES [Houses].[Users] ([UserId])
END
GO
