CREATE OR ALTER PROCEDURE [Houses].[Occupants_Of_Household]
	@OccupantId AS INT
AS
SELECT
	OccupantId 
		, UserId
		, DisplayName 
		, HouseholdId
FROM Houses.Occupants
WHERE OccupantId = @OccupantId

GO
