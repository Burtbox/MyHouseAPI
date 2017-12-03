CREATE OR ALTER PROCEDURE [Houses].[Households_Insert]
	@Name AS NVARCHAR(50),
	@EnteredBy AS NVARCHAR(50)

AS
INSERT INTO [Houses].Households
	(Name, EnteredBy, ModifiedBy)
VALUES
	(@Name, @EnteredBy, @EnteredBy)

GO
