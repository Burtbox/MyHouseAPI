CREATE OR ALTER PROCEDURE [Houses].[Occupant_Exists]
	@HouseholdId AS INT,
	@OccupantId as INT
AS
SELECT
	HouseholdId
FROM Houses.Occupants
WHERE HouseholdId = @HouseholdId and OccupantId = @OccupantId

GO
