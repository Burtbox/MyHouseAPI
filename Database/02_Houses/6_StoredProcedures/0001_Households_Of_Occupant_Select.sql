CREATE OR ALTER PROCEDURE Houses.Households_Of_Occupant_Select
	@UserId AS VARCHAR(36),
	@IncludeInvites AS BIT = 0
AS
BEGIN
	SELECT
		Occ.OccupantId
		, Hh.Name
		, Occ.InviteAccepted
	FROM Houses.Occupants as Occ
		INNER JOIN Houses.Households as Hh ON Occ.HouseholdId = Hh.HouseholdId
	WHERE UserId = @UserId
		AND (InviteAccepted = 1
		OR (@IncludeInvites = 1 AND InviteAccepted = 0))
	ORDER BY Occ.InviteAccepted desc, Hh.Name
END
GO
