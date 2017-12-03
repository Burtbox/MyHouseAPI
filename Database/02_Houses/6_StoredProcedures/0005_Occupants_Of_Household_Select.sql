CREATE OR ALTER PROCEDURE [Houses].[Occupants_Of_Household]
	@HouseholdId AS INT
AS
SELECT
	OccupantId 
		, UserId
		, DisplayName 
		, HouseholdId
FROM Houses.Occupants
WHERE HouseholdId = @HouseholdId

GO
