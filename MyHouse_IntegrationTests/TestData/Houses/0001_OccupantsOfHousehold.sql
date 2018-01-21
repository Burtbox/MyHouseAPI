exec houses.Households_Insert 
	  @Name = 'Hh1'
	, @EnteredBy = 'IntegrationTest'

exec houses.Households_Insert 
	  @Name = 'Hh2'
	, @EnteredBy = 'IntegrationTest'

exec houses.Occupants_Insert 
      @UserId = '70ajxWmrS6XIU53GL6bj1VcjCsm1'
    , @DisplayName = 'O1DispName'
    , @HouseholdId = 1
                
exec houses.Occupants_Insert 
      @UserId = 'zzrmi1i7nsApSvmeqA9QSIx1zwfs'
    , @DisplayName = 'O2DispName'
    , @HouseholdId = 1
                
-- Add user outside of queried household
exec houses.Occupants_Insert 
	  @UserId = 'zHhRt5d5N7jED5yzSYZAbFYXpRHI'
    , @DisplayName = 'O3DispName'
    , @HouseholdId = 2
                