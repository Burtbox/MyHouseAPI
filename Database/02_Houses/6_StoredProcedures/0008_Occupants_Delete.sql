CREATE OR ALTER PROCEDURE Houses.Occupants_Delete
	@OccupantId AS INT,
	@HouseholdId AS INT
AS
BEGIN
	DELETE FROM Houses.Occupants 
	WHERE OccupantId = @OccupantId
		AND HouseholdId = @HouseholdId
END
GO
