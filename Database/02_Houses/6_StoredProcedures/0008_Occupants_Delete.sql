CREATE OR ALTER PROCEDURE [Houses].[Occupants_Delete] 
@OccupantId AS INT
AS
	DELETE FROM Houses.Occupants 
	WHERE OccupantId = @OccupantId

GO
