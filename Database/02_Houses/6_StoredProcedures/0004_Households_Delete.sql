CREATE OR ALTER PROCEDURE Houses.Households_Delete
	@HouseholdId AS INT

AS
BEGIN
	DELETE FROM HOUSEHOLDS 
	WHERE HouseholdId = @HouseholdId
END
GO
