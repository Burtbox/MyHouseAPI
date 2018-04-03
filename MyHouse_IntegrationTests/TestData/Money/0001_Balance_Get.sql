exec [Money].[Transaction_Insert]
@Creditor = 1,
@Debtor = 4,
@Gross ='4.20',
@Reference ='Test Tran Between dickbutt(1) and Household 1 occupant O2DispName(4)',
@Date = '2018-03-17 15:19:08.537',
@EnteredBy = 1

-- Setup balance occupants
exec Houses.Occupants_Insert 
@DisplayName = 'Household 3 Bal Test 1',
@UserId = 'tl4CZ3hAwyb4YGN473H2oSFcI6gU',
@OccupantId = 3,
@EnteredBy = 'jp9ZAlmz7gV9b74kzniROTSRZxz1'

exec Houses.Occupants_Insert 
@DisplayName = 'Household 3 Bal Test 2',
@UserId = 'TfAbO1d90cBtwxm2mm9g5ZO92J3p',
@OccupantId = 3,
@EnteredBy = 'jp9ZAlmz7gV9b74kzniROTSRZxz1'

exec Houses.Occupants_Insert 
@DisplayName = 'Household 3 Bal Test 3',
@UserId = 'jig0CWXvwL6Hj9S3pVGF6H6R68P4',
@OccupantId = 3,
@EnteredBy = 'jp9ZAlmz7gV9b74kzniROTSRZxz1'

-- Add transactions to balance occupants 
exec [Money].[Transaction_Insert]
@Creditor = 3,
@Debtor = 10,
@Gross ='2.40',
@Reference ='Test Tran Between dickbutt3(3) and Household 2 Bal Test 1(10)',
@Date = '2018-03-18 15:19:08.537',
@EnteredBy = 3

exec [Money].[Transaction_Insert]
@Creditor = 3,
@Debtor = 11,
@Gross ='4.22',
@Reference ='Test Tran Between Household 2 Bal Test 2(11) and dickbutt3(3)',
@Date = '2018-03-19 15:19:08.537',
@EnteredBy = 3

exec [Money].[Transaction_Insert]
@Creditor = 12,
@Debtor = 11,
@Gross ='6.55',
@Reference ='Test Tran Between Household 2 Bal Test 2(11) and Household 2 Bal Test 3(12)',
@Date = '2018-03-20 21:19:07.500',
@EnteredBy = 12

exec [Money].[Transaction_Insert]
@Creditor = 10,
@Debtor = 3,
@Gross ='2.44',
@Reference ='Test Tran Between Household 2 Bal Test 1(10) and dickbutt3(3)',
@Date = '2018-03-17 01:01:00.010',
@EnteredBy = 10

