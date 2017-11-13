IF OBJECT_ID(N'[Houses].[Occupants_Of_Household]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Houses].[Occupants_Of_Household] 
END
GO 

CREATE PROCEDURE [Houses].[Occupants_Of_Household] 
@HouseholdId AS INT
AS
	SELECT 
		Occupants.OccupantId 
		, Occupants.DisplayName 
	FROM Houses.Households
	INNER JOIN Houses.Occupants ON Houses.Occupants.HouseholdId = Houses.Households.HouseholdId
	WHERE Households.HouseholdId = @HouseholdId

GO
