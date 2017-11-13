IF OBJECT_ID(N'[Houses].[Occupants_Update]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Houses].[Occupants_Update] 
END
GO 

CREATE PROCEDURE [Houses].[Occupants_Update]
@UserId AS NVARCHAR(36)
, @DisplayName AS VARCHAR(100)

AS
	UPDATE Houses.Occupants 
	SET DisplayName = @DisplayName
	WHERE UserId = @UserId -- This will update their display name for all households
	
GO

