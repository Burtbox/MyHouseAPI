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
