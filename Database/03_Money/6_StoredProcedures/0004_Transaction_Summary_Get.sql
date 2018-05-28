CREATE OR ALTER PROCEDURE Money.Transaction_Summary_Get
	@OccupantId AS INT
AS
BEGIN
	SELECT
		Summary.CreditorDisplayName 
      , Summary.DebtorDisplayName  
	  , Summary.Gross
	  , Summary.CreditorOccupantId
	  , Summary.DebtorOccupantId
	  , Summary.CreditorHouseholdId
	  , Summary.DebtorHouseholdId
	FROM Money.TransactionSummary AS Summary
	WHERE EXISTS (
		SELECT * 
		FROM Houses.Occupants AS Occs 
		WHERE Occs.OccupantId = @OccupantId 
			AND Summary.CreditorHouseholdId = Occs.HouseholdId
	)
END
GO
