CREATE OR ALTER PROCEDURE Houses.Households_Insert
	@Name AS NVARCHAR(50),
	@EnteredBy AS NVARCHAR(36),
	@CreatorDisplayName AS NVARCHAR(100)
AS
BEGIN
	DECLARE @NewHouseholdIdTable TABLE (
		HouseholdId INT NOT NULL,
		Name NVARCHAR(50) NOT NULL
	)

	--Create the new household
	INSERT INTO Houses.Households
		(Name, EnteredBy, ModifiedBy)
	OUTPUT
	INSERTED.HouseholdId, INSERTED.Name into @NewHouseholdIdTable
	VALUES
		(@Name, @EnteredBy, @EnteredBy)

	--The creator of the household is made an occupant
	DECLARE @NewHouseholdId INT = (SELECT TOP (1)
		HouseholdId
	FROM @NewHouseholdIdTable)
	INSERT INTO Houses.Occupants
		(UserId, DisplayName, HouseholdId, EnteredBy, ModifiedBy)
	OUTPUT
	INSERTED.OccupantId,
	@Name As Name
	VALUES
		(@EnteredBy, @CreatorDisplayName, @NewHouseholdId, @EnteredBy, @EnteredBy)

END
GO
