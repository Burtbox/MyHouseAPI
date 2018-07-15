CREATE OR ALTER PROCEDURE Houses.Occupants_Insert
	@UserId AS NVARCHAR(36),
	@DisplayName AS VARCHAR(100),
	@InvitedByOccupantId AS int,
	@EnteredBy AS NVARCHAR(36),
	@InviteAccepted as BIT = 0
AS
BEGIN
	DECLARE @HouseholdId AS INT = 
	(SELECT HouseholdId
	FROM Houses.Occupants
	WHERE OccupantId = @InvitedByOccupantId)


	INSERT INTO Houses.Occupants
		(UserId, DisplayName, HouseholdId, InviteAccepted, EnteredBy, ModifiedBy)
	OUTPUT
	INSERTED.OccupantId,
	INSERTED.UserId,
	INSERTED.DisplayName,
	INSERTED.HouseholdId,
	INSERTED.InviteAccepted
	VALUES
		(@UserId, @DisplayName, @HouseholdId, @InviteAccepted, @EnteredBy, @EnteredBy)
END
GO
