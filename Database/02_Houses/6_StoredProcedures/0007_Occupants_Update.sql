CREATE OR ALTER PROCEDURE [Houses].[Occupants_Update]
@UserId AS NVARCHAR(36)
, @DisplayName AS VARCHAR(100)

AS
	UPDATE Houses.Occupants 
	SET DisplayName = @DisplayName
	WHERE UserId = @UserId -- This will update their display name for all households
	
GO

