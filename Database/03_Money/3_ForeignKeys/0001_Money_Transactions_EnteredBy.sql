IF OBJECT_ID(N'Money.FK__Money__Transactions__EnteredBy', 'F') IS NULL
BEGIN
	ALTER TABLE Money.Transactions  WITH CHECK 
	ADD CONSTRAINT FK__Money__Transactions__EnteredBy 
	FOREIGN KEY(EnteredBy)
	REFERENCES Houses.Occupants (OccupantId)
END
GO
