IF NOT EXISTS (SELECT name FROM sys.schemas WHERE name = N'Food')
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Food]'
END
GO
