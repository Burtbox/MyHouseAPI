CREATE OR ALTER PROCEDURE Houses.Households_Insert
	@Name AS NVARCHAR(50),
	@EnteredBy AS NVARCHAR(36),
	@CreatorDisplayName AS NVARCHAR(100)
AS
BEGIN
	DECLARE @NewHouseholdIdTable TABLE (HouseholdId INT, Name NVARCHAR(50))

	--Create the new household
	INSERT INTO Houses.Households
		(Name, EnteredBy, ModifiedBy)
	OUTPUT
	INSERTED.HouseholdId, INSERTED.Name into @NewHouseholdIdTable
	VALUES
		(@Name, @EnteredBy, @EnteredBy)

	--The creator of the household is made an occupant
	DECLARE @NewHouseholdId INT = (SELECT TOP (1) HouseholdId FROM @NewHouseholdIdTable)
	INSERT INTO Houses.Occupants
	(UserId, DisplayName, HouseholdId, EnteredBy, ModifiedBy)
	VALUES
	(@EnteredBy, @CreatorDisplayName, @NewHouseholdId, @EnteredBy, @EnteredBy)

	SELECT HouseholdId, Name FROM @NewHouseholdIdTable
END
GO
