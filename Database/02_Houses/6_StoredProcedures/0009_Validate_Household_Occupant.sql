CREATE OR ALTER PROCEDURE [Houses].[Validate_Household_Occupant]
	@HouseholdId AS INT,
	@UserId as NVARCHAR(36)
AS

SELECT
	COUNT(1)
FROM Houses.Occupants
WHERE HouseholdId = @HouseholdId and UserId = @UserId 

GO
