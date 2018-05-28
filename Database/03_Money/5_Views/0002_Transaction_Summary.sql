CREATE OR ALTER VIEW Money.TransactionSummary
AS
	SELECT Positive.DisplayName AS CreditorDisplayName 
     , Negative.DisplayName AS DebtorDisplayName  
	 , TotalPositive.Total - TotalNegative.Total AS Gross
	 , Positive.OccupantId AS CreditorOccupantId
	 , Negative.OccupantId AS DebtorOccupantId
	 , Positive.HouseholdId as CreditorHouseholdId
	 , Negative.HouseholdId as DebtorHouseholdId
	FROM Houses.Occupants AS Positive
	CROSS JOIN Houses.Occupants AS Negative
	OUTER APPLY (SELECT ISNULL(SUM(GROSS), 0.00) AS Total
		FROM Money.Transactions
		WHERE Creditor = Positive.OccupantId AND Debtor = Negative.OccupantId
				) AS TotalPositive
	OUTER APPLY (SELECT ISNULL(SUM(GROSS), 0.00) AS Total
		FROM Money.Transactions
		WHERE Creditor = Negative.OccupantId AND Debtor = Positive.OccupantId
				) AS TotalNegative
	WHERE Positive.HouseholdId = Negative.HouseholdId
GO
