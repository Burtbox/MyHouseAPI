IF OBJECT_ID('Food.Days_GetNumberOfPeople') IS NULL
BEGIN
	execute dbo.sp_executesql @statement = N'
	CREATE FUNCTION Food.Days_GetNumberOfPeople (@Date date)
	RETURNS TINYINT
	AS
	BEGIN
		DECLARE @NumberOfPeople TINYINT
		SELECT @NumberOfPeople = COUNT(*)
		FROM Food.People
		WHERE Date = @Date
		RETURN @NumberOfPeople
	END'
END
GO
