IF OBJECT_ID(N'Houses.FK__Houses__Occupants__HouseholdId', 'F') IS NULL
BEGIN
	ALTER TABLE Houses.Occupants  WITH CHECK
	ADD  CONSTRAINT FK__Houses__Occupants__HouseholdId 
	FOREIGN KEY(HouseholdId)
	REFERENCES Houses.Households (HouseholdId)
END
GO
