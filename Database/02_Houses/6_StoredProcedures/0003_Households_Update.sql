CREATE OR ALTER PROCEDURE [Houses].[Households_Update]
	@HouseholdId AS INT,
	@Name AS NVARCHAR(50),
	@ModifiedBy AS NVARCHAR(36)

AS
UPDATE Houses.Households 
	SET Name = @Name 
	, ModifiedBy = @ModifiedBy
	, ModifiedDate = GETUTCDATE()
	OUTPUT 
	INSERTED.HouseholdId
	, INSERTED.Name
	WHERE HouseholdId = @HouseholdId
GO
