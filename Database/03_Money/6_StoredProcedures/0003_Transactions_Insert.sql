IF OBJECT_ID(N'[Money].[Transactions_Insert]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Money].[Transactions_Insert]
END
GO 

CREATE PROCEDURE [Money].[Transactions_Insert] 
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
