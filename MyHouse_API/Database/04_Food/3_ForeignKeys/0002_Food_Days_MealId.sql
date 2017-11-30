IF OBJECT_ID(N'[Food].[FK__Food__Days__MealId]', 'F') IS NULL
BEGIN
	ALTER TABLE [Food].[Days]  WITH CHECK 
	ADD  CONSTRAINT [FK__Food__Days__MealId] 
	FOREIGN KEY([MealId])
	REFERENCES [Food].[Meals] ([MealId])
END
GO
