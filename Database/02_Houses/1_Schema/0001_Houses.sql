IF SCHEMA_ID(N'Houses') IS NULL
BEGIN
	EXEC sys.sp_executesql N'CREATE SCHEMA Houses'
END
GO
