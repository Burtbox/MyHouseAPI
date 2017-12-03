CREATE OR ALTER PROCEDURE [Houses].[Households_Update]
	@HouseholdId AS INT,
	@Name AS NVARCHAR(50)

AS
UPDATE Houses.Households 
	SET Name = @Name 
	WHERE HouseholdId = @HouseholdId
GO
