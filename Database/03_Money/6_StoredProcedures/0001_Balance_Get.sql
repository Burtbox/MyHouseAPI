CREATE OR ALTER PROCEDURE [Money].[Balance_Get]
	@OccupantId as INT
AS
BEGIN
	SELECT Ts.CreditorDisplayName
		, Ts.DebtorDisplayName
		, Ts.CreditorOccupantId
		, Ts.DebtorOccupantId
		, Ts.Gross
	FROM [Money].[TransactionSummary] as Ts
	INNER JOIN Houses.Occupants as Occ ON Occ.OccupantId = @OccupantId
	WHERE Ts.CreditorOccupantId = @OccupantId 
		and Ts.CreditorHouseholdId = Occ.HouseholdId 
		and Ts.DebtorHouseholdId = Occ.HouseholdId
		and Ts.CreditorOccupantId <> Ts.DebtorOccupantId
END
GO
