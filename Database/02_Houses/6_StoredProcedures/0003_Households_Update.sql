IF OBJECT_ID(N'[Houses].[Households_Update]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Houses].[Households_Update] 
END
GO 

CREATE PROCEDURE [Houses].[Households_Update] 
@HouseholdId AS INT
, @Name AS NVARCHAR(50)

AS
	UPDATE Houses.Households 
	SET Name = @Name 
	WHERE HouseholdId = @HouseholdId
GO
