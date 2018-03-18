CREATE OR ALTER PROCEDURE [Houses].[Occupants_Insert]
	@UserId AS NVARCHAR(36),
	@DisplayName AS VARCHAR(100),
	@OccupantId AS int,
	@EnteredBy AS NVARCHAR(36)

AS
DECLARE @HouseholdId AS INT
SELECT @HouseholdId = HouseholdId 
FROM Houses.Occupants 
WHERE OccupantId = @OccupantId

INSERT INTO Houses.Occupants
	(UserId, DisplayName, HouseholdId, EnteredBy, ModifiedBy)
OUTPUT
INSERTED.OccupantId,
INSERTED.UserId,
INSERTED.DisplayName,
INSERTED.HouseholdId
VALUES
	(@UserId, @DisplayName, @HouseholdId, @EnteredBy, @EnteredBy)

GO
