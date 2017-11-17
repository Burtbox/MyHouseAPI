CREATE OR ALTER FUNCTION [Food].[Days_GetNumberOfPeople] (@Date date)
RETURNS TINYINT
AS
BEGIN
  DECLARE @NumberOfPeople TINYINT
  SELECT @NumberOfPeople = COUNT(*)
  FROM [Food].[People]
  WHERE [Date] = @Date
  RETURN @NumberOfPeople
END

GO
