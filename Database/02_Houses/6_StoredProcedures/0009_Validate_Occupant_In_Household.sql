CREATE OR ALTER PROCEDURE [Houses].[Validate_Occupant_In_Household]
	@OccupantId AS INT,
	@UserId as NVARCHAR(36)
AS
BEGIN
	SELECT
		COUNT(1)
	FROM Houses.Occupants
	WHERE OccupantId = @OccupantId and UserId = @UserId
END
GO
