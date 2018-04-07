-- Setup balance occupants
exec Houses.Occupants_Insert 
@DisplayName = 'dickbutt3',
@UserId = 'jp9ZAlmz7gV9b74kzniROTSRZxz1',
@OccupantId = 2,
@EnteredBy = 'SbYFUv0fO8VLzotVFcTUn9uzhB02'

-- Add transactions to balance occupants 
exec Money.Transaction_Insert
@Creditor = 2,
@Debtor = 5,
@Gross ='1.11',
@Reference ='Test Tran Between dickbutt2(2) and Household 2 occupant O2DispName(5)',
@Date = '2018-04-07',
@EnteredBy = 2

exec Money.Transaction_Insert
@Creditor = 2,
@Debtor = 5,
@Gross ='-15.76',
@Reference ='Test Tran Between dickbutt2(2) and Household 2 occupant O2DispName(5)',
@Date = '2018-04-09',
@EnteredBy = 2

exec Money.Transaction_Insert
@Creditor = 2,
@Debtor = 6,
@Gross ='166.59',
@Reference ='Test Tran Between dickbutt2(2) and Household 2 occupant put(6)',
@Date = '2018-04-11',
@EnteredBy = 2

exec Money.Transaction_Insert
@Creditor = 2,
@Debtor = 5,
@Gross ='2.00',
@Reference ='Test Tran Between dickbutt2(2) and Household 2 occupant O2DispName(5)',
@Date = '2018-04-21',
@EnteredBy = 2

exec Money.Transaction_Insert
@Creditor = 3,
@Debtor = 2,
@Gross ='3.40',
@Reference ='Test Tran Between dickbutt3(3) and dickbutt2(2)',
@Date = '2018-12-10',
@EnteredBy = 3
