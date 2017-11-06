IF OBJECT_ID(N'[Houses].[Occupants_Insert]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Houses].[Occupants_Insert] 
END
GO 

CREATE PROCEDURE [Houses].[Occupants_Insert] 
@UserId AS NVARCHAR(36)
, @DisplayName AS VARCHAR(100)
, @HouseholdId AS INT
AS
	INSERT INTO Houses.Occupants (UserId, DisplayName, HouseholdId)
	VALUES (@UserId, @DisplayName, @HouseholdId)

GO
