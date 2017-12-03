CREATE OR ALTER PROCEDURE [Houses].[Occupants_Insert]
	@UserId AS NVARCHAR(36),
	@DisplayName AS VARCHAR(100),
	@HouseholdId AS INT

AS
INSERT INTO Houses.Occupants
	(UserId, DisplayName, HouseholdId, EnteredBy, ModifiedBy)
OUTPUT
INSERTED.OccupantId,
INSERTED.UserId,
INSERTED.DisplayName,
INSERTED.HouseholdId
VALUES
	(@UserId, @DisplayName, @HouseholdId, @UserId, @UserId)

GO
