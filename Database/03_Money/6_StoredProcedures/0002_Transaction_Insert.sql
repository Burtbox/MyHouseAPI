CREATE OR ALTER PROCEDURE Money.Transaction_Insert
	@CreditorOccupantId AS INT,
	@DebtorOccupantId AS INT,
	@Gross AS DECIMAL(18,2),
	@Reference AS VARCHAR(200),
	@Date AS DATE
AS
BEGIN
	INSERT INTO Transactions
		(
		Creditor
		, Debtor
		, Gross
		, Reference
		, Date
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
	inserted.Date
	,
	inserted.Reference
	VALUES
		(
			@CreditorOccupantId
		, @DebtorOccupantId
		, @Gross
		, @Reference
		, @Date
		, @CreditorOccupantId
		, @CreditorOccupantId
	)
END
GO
