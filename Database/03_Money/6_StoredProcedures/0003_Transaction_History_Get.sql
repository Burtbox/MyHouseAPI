CREATE OR ALTER PROCEDURE Money.Transaction_History_Get
	@OccupantId AS INT,
	@PageSize AS INT,
	@PageNumber AS INT
AS
BEGIN
	SELECT
	 PrimaryKey 
	 , TransactionId
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
	 ORDER BY Date DESC, EnteredDate DESC, TransactionId DESC
	 OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT (@PageSize) ROWS ONLY
END
GO
