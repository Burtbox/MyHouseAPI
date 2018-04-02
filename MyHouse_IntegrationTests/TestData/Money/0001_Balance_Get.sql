exec [Money].[Transactions_Insert]
@Creditor = 1,
@Debtor = 3,
@Gross ='4.20',
@Reference ='Test Tran Between dickbutt(1) and Household 1 occupant O2DispName(3)',
@Date = '2018-03-17 15:19:08.537',
@EnteredBy = 1

exec [Money].[Transactions_Insert]
@Creditor = 2,
@Debtor = 4,
@Gross ='2.40',
@Reference ='Test Tran Between dickbutt2(2) and Household 2 occupant Household 2 occupant O2DispName(4)',
@Date = '2018-03-18 15:19:08.537',
@EnteredBy = 1

exec [Money].[Transactions_Insert]
@Creditor = 2,
@Debtor = 5,
@Gross ='4.22',
@Reference ='Test Tran Between Household 2 occupant Household 2 occupant put(5) and dickbutt2(2)',
@Date = '2018-03-19 15:19:08.537',
@EnteredBy = 1

exec [Money].[Transactions_Insert]
@Creditor = 6,
@Debtor = 5,
@Gross ='6.55',
@Reference ='Test Tran Between dickbutt2(2) and Household 2 occupant Household 2 occupant delete(6)',
@Date = '2018-03-20 21:19:07.500',
@EnteredBy = 1

exec [Money].[Transactions_Insert]
@Creditor = 4,
@Debtor = 2,
@Gross ='2.44',
@Reference ='Test Tran Between Household 2 occupant Household 2 occupant O2DispName(4) and dickbutt2(2)',
@Date = '2018-03-17 01:01:00.010',
@EnteredBy = 1

