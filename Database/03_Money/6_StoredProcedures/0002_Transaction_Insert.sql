CREATE OR ALTER PROCEDURE [Money].[Transaction_Insert]
	@Creditor AS INT,
	@Debtor AS INT,
	@Gross AS DECIMAL(18,2),
	@Reference AS VARCHAR(200),
	@Date AS DATE,
	@EnteredBy AS INT
AS
BEGIN
	INSERT INTO Transactions
		(
		Creditor
		, Debtor
		, Gross
		, Reference
		, [Date]
		, EnteredBy
		, ModifiedBy
		)
	OUTPUT
	inserted.TransactionId
	,
	inserted.Creditor
	,
	inserted.Debtor
	,
	inserted.Gross
	,
	inserted.[Date]
	,
	inserted.Reference
	VALUES
		(
			@Creditor
		, @Debtor
		, @Gross
		, @Reference
		, @Date
		, @EnteredBy
		, @EnteredBy
	)
END
GO
