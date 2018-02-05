CREATE OR ALTER PROCEDURE [Houses].[Occupants_Delete]
	@OccupantId AS INT,
	@HouseholdId AS INT 
AS
DELETE FROM Houses.Occupants 
	WHERE OccupantId = @OccupantId 
		AND HouseholdId = @HouseholdId

GO
