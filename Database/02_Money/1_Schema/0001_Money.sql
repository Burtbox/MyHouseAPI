IF SCHEMA_ID(N'[Money]') IS NOT NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Money]'
END
GO
