IF OBJECT_ID(N'[Houses].[Households_Delete]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Houses].[Households_Delete] 
END
GO 

CREATE PROCEDURE [Houses].[Households_Delete] 
@HouseholdId AS INT

AS
	DELETE FROM HOUSEHOLDS 
	WHERE HouseholdId = @HouseholdId
GO
