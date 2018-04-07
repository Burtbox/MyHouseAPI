CREATE OR ALTER PROCEDURE Houses.Households_Update
	@OccupantId AS INT,
	@Name AS NVARCHAR(50),
	@ModifiedBy AS NVARCHAR(36)

AS
BEGIN
	UPDATE Houses.Households 
	SET Name = @Name 
	, ModifiedBy = @ModifiedBy
	, ModifiedDate = GETUTCDATE()
	OUTPUT 
	Occ.OccupantId
	, INSERTED.Name
	FROM Houses.Households  as Hh
		INNER JOIN Houses.Occupants as Occ ON Hh.HouseholdId = Occ.HouseholdId
	WHERE OccupantId = @OccupantId
END 
GO
