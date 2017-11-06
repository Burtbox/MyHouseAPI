IF NOT EXISTS (SELECT name FROM sys.schemas WHERE name = N'Houses')
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Houses]'
END
GO
