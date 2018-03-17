CREATE OR ALTER PROCEDURE [Money].[Balance_Get]
	@OccupantId as INT
AS
	SELECT Creditor
		, Debtor
		, Gross
	FROM [Money].[TransactionSummary] 
	INNER JOIN Houses.Occupants ON OccupantId = @OccupantId
	WHERE CreditorOccupantId = @OccupantId 
		and CreditorHouseholdId = HouseholdId 
		and DebtorHouseholdId = HouseholdId

GO
