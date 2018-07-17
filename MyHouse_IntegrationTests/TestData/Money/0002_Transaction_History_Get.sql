-- Setup transaction history household
exec Houses.Households_Insert
@Name = 'Household 6 owner dickbutt3',
@CreatorDisplayName = 'dickbutt3',
@EnteredBy = 'jp9ZAlmz7gV9b74kzniROTSRZxz1'

-- Setup transaction history occupants
exec Houses.Occupants_Insert 
@DisplayName = 'dickbutt',
@UserId = '70ajxWmrS6XIU53GL6bj1VcjCsm1',
@InvitedByOccupantId = 13,
@EnteredBy = 'jp9ZAlmz7gV9b74kzniROTSRZxz1'

exec Houses.Occupants_Insert 
@DisplayName = 'Transaction History DU1',
@UserId = 'n502RYQixi1UH7N75CXFe5aGSzjb',
@InvitedByOccupantId = 13,
@EnteredBy = 'jp9ZAlmz7gV9b74kzniROTSRZxz1'

exec Houses.Occupants_Insert 
@DisplayName = 'Transaction History DU2',
@UserId = 'wblrtCG19vP9iMEixa4Tr9vQM6L9',
@InvitedByOccupantId = 13,
@EnteredBy = 'jp9ZAlmz7gV9b74kzniROTSRZxz1'

-- Add transactions to balance occupants 
exec Money.Transaction_Insert
@CreditorOccupantId = 13,
@DebtorOccupantId = 15,
@Gross ='1.11',
@Reference ='Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)',
@Date = '2018-04-07'

exec Money.Transaction_Insert
@CreditorOccupantId = 13,
@DebtorOccupantId = 15,
@Gross ='-15.76',
@Reference ='Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)',
@Date = '2018-04-09'

exec Money.Transaction_Insert
@CreditorOccupantId = 13,
@DebtorOccupantId = 16,
@Gross ='166.59',
@Reference ='Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU2(16)',
@Date = '2018-04-11'

exec Money.Transaction_Insert
@CreditorOccupantId = 13,
@DebtorOccupantId = 15,
@Gross ='2.00',
@Reference ='Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)',
@Date = '2018-04-21'

exec Money.Transaction_Insert
@CreditorOccupantId = 14,
@DebtorOccupantId = 13,
@Gross ='3.40',
@Reference ='Test Tran Between dickbutt(1) and dickbutt3(3)',
@Date = '2018-12-10'
