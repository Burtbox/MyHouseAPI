CREATE OR ALTER PROCEDURE [Houses].[Occupants_Insert] 
@UserId AS NVARCHAR(36)
, @DisplayName AS VARCHAR(100)
, @HouseholdId AS INT
AS
	INSERT INTO Houses.Occupants (UserId, DisplayName, HouseholdId)
	VALUES (@UserId, @DisplayName, @HouseholdId)

GO
