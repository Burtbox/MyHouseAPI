CREATE OR ALTER PROCEDURE Houses.Occupants_Of_Household_Select
	@OccupantId AS INT
AS
BEGIN
	Declare @HouseholdId AS INT = (
	SELECT HouseholdId
	FROM Houses.Occupants as Me
	WHERE Me.OccupantId = @OccupantId
	)

	SELECT
		Occs.OccupantId 
		, Occs.UserId
		, Occs.DisplayName 
		, Occs.HouseholdId
		, Occs.InviteAccepted
	FROM Houses.Occupants as Occs
	WHERE Occs.HouseholdId = @HouseholdId
END
GO
