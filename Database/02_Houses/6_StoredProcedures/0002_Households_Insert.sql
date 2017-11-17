CREATE OR ALTER PROCEDURE [Houses].[Households_Insert] 
@Name AS NVARCHAR(50)

AS
	INSERT INTO [Houses].Households (Name)
	VALUES (@Name)

GO
