IF SCHEMA_ID(N'[Houses]') IS NOT NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Houses]'
END
GO
