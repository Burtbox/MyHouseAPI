CREATE OR ALTER PROCEDURE Houses.Occupants_Update
	@UserId AS NVARCHAR(36),
	@DisplayName AS VARCHAR(100),
	@InviteAccepted AS BIT,
	@OccupantId AS INT

AS
BEGIN
	-- This will update their display name for all households
	UPDATE Houses.Occupants 
	SET DisplayName = @DisplayName
	, ModifiedBy = @UserId
	, ModifiedDate = GETUTCDATE()
	WHERE UserId = @UserId

	UPDATE Households.Occupants 
	SET InviteAccepted = @InviteAccepted
	WHERE UserId = @UserId AND OccupantId = @OccupantId

	SELECT OccupantId, UserId, DisplayName, HouseholdId
	FROM Houses.Occupants
	WHERE UserId = @UserId AND OccupantId = @OccupantId
END
GO
