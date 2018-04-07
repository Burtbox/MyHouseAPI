CREATE OR ALTER VIEW Money.TransactionHistory
AS
	SELECT 'credit' + CAST(ROW_NUMBER() OVER (ORDER BY DATE) AS NVARCHAR(1000)) AS PRIMARYKEY
     , Credits.Creditor AS CreditorOccupantId
	 , CreditorOccupant.DisplayName AS CreditorDisplayName
	 , Credits.Debtor AS DebtorOccupantId
	 , DebtorOccupant.DisplayName AS DebtorDisplayName
	 , Credits.Gross 
	 , Credits.Reference 
	 , Credits.Date 
	 , Credits.EnteredBy AS EnteredByOccupantId
	 , EnteredByOccupant.DisplayName AS EnteredByDisplayName
	 , Credits.EnteredDate
	FROM Money.Transactions as Credits
		INNER JOIN Houses.Occupants as CreditorOccupant ON Credits.Creditor = CreditorOccupant.OccupantId
		INNER JOIN Houses.Occupants as DebtorOccupant ON Credits.Debtor = DebtorOccupant.OccupantId
		INNER JOIN Houses.Occupants as EnteredByOccupant ON Credits.EnteredBy = EnteredByOccupant.OccupantId

	UNION ALL

	SELECT 'debt' + CAST(ROW_NUMBER() OVER (ORDER BY DATE) AS NVARCHAR(1000)) AS PRIMARYKEY 
     , Debts.Debtor  AS CreditorOccupantId
	 , CreditorOccupant.DisplayName AS CreditorDisplayName
	 , Debts.Creditor AS DebtorOccupantId
	 , DebtorOccupant.DisplayName AS DebtorDisplayName
	 , Debts.Gross * -1 AS Gross
	 , Debts.Reference 
	 , Debts.Date 
	 , Debts.EnteredBy AS EnteredByOccupantId
	 , EnteredByOccupant.DisplayName AS EnteredByDisplayName
	 , Debts.EnteredDate
	FROM Money.Transactions as Debts
		INNER JOIN Houses.Occupants as CreditorOccupant ON Debts.Debtor = CreditorOccupant.OccupantId
		INNER JOIN Houses.Occupants as DebtorOccupant ON  Debts.Creditor = DebtorOccupant.OccupantId
		INNER JOIN Houses.Occupants as EnteredByOccupant ON Debts.EnteredBy = EnteredByOccupant.OccupantId
GO
