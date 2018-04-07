CREATE OR ALTER PROCEDURE Money.Transaction_History_Get
	@OccupantId AS INT
AS
BEGIN
	SELECT 
	 PRIMARYKEY 
     , CreditorOccupantId 
	 , CreditorDisplayName
	 , DebtorOccupantId 
	 , DebtorDisplayName
	 , Gross 
	 , Reference 
	 , Date 
	 , EnteredByOccupantId
	 , EnteredByDisplayName 
	 , EnteredDate 
	 FROM Money.TransactionHistory
	 WHERE CreditorOccupantId = @OccupantId
END
GO
