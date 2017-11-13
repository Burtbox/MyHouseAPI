IF SCHEMA_ID(N'Diagnostics') IS NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA [Diagnostics]'
END
GO
