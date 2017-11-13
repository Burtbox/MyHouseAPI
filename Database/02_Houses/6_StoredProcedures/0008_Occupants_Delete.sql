IF OBJECT_ID(N'[Houses].[Occupants_Delete]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Houses].[Occupants_Delete] 
END
GO 

CREATE PROCEDURE [Houses].[Occupants_Delete] 
@OccupantId AS INT
AS
	DELETE FROM Houses.Occupants 
	WHERE OccupantId = @OccupantId

GO
