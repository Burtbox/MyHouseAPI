CREATE OR ALTER PROCEDURE [Houses].[Households_Insert]
	@Name AS NVARCHAR(50),
	@EnteredBy AS NVARCHAR(36)

AS
INSERT INTO [Houses].Households
	(Name, EnteredBy, ModifiedBy)
OUTPUT
INSERTED.HouseholdId,
INSERTED.Name
VALUES
	(@Name, @EnteredBy, @EnteredBy)

GO
