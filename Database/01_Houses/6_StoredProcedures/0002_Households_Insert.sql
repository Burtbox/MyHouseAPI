IF OBJECT_ID(N'[Houses].[Households_Insert]', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE [Houses].[Households_Insert] 
END
GO 

CREATE PROCEDURE [Houses].[Households_Insert] 
@Name AS NVARCHAR(50)

AS
	INSERT INTO [Houses].Households (Name)
	VALUES (@Name)

GO
