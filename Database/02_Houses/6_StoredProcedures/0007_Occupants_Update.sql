CREATE OR ALTER PROCEDURE [Houses].[Occupants_Update]
	@UserId AS NVARCHAR(36),
	@DisplayName AS VARCHAR(100),
	@OccupantId AS INT,
	@HouseholdId AS INT

AS
	UPDATE Houses.Occupants 
	SET DisplayName = @DisplayName
	, ModifiedBy = @OccupantId
	, ModifiedDate = GETUTCDATE()
	WHERE UserId = @UserId -- This will update their display name for all households

	SELECT OccupantId, UserId, DisplayName, HouseholdId 
	FROM Houses.Occupants WHERE OccupantId = @OccupantId
GO
