CREATE OR ALTER PROCEDURE [Houses].[Households_Of_Occupant] 
@UserId AS INT
AS
	SELECT 
		Households.HouseholdId
		, Households.Name 
	FROM Houses.Occupants
	INNER JOIN Houses.Households ON Houses.Occupants.HouseholdId = Houses.Households.HouseholdId
	WHERE UserId = @UserId

GO