CREATE OR ALTER PROCEDURE Houses.Households_Of_Occupant_Select
	@UserId AS VARCHAR(36)
AS
BEGIN
	SELECT
		Occ.OccupantId
		, Hh.Name
	FROM Houses.Occupants as Occ
		INNER JOIN Houses.Households as Hh ON Occ.HouseholdId = Hh.HouseholdId
	WHERE UserId = @UserId
END
GO
