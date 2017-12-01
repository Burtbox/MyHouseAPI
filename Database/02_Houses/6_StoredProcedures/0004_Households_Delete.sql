CREATE OR ALTER PROCEDURE [Houses].[Households_Delete] 
@HouseholdId AS INT

AS
	DELETE FROM HOUSEHOLDS 
	WHERE HouseholdId = @HouseholdId
GO
