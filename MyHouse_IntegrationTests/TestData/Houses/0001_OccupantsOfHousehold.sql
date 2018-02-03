exec houses.Households_Insert 
	  @Name = 'Household 1 owner dickbutt'
	, @EnteredBy = '70ajxWmrS6XIU53GL6bj1VcjCsm1'

exec houses.Households_Insert 
	  @Name = 'Household 2 owner dickbutt2'
	, @EnteredBy = 'SbYFUv0fO8VLzotVFcTUn9uzhB02'

exec houses.Occupants_Insert 
      @UserId = '70ajxWmrS6XIU53GL6bj1VcjCsm1'
    , @DisplayName = 'Household 1 occupant dickbutt'
    , @HouseholdId = 1
	  , @EnteredBy = '70ajxWmrS6XIU53GL6bj1VcjCsm1'

exec houses.Occupants_Insert 
      @UserId = 'zzrmi1i7nsApSvmeqA9QSIx1zwfs'
    , @DisplayName = 'Household 1 occupant O2DispName'
    , @HouseholdId = 1
	  , @EnteredBy = '70ajxWmrS6XIU53GL6bj1VcjCsm1'

-- Add user outside of queried household
exec houses.Occupants_Insert 
	  @UserId = 'SbYFUv0fO8VLzotVFcTUn9uzhB02'
    , @DisplayName = 'Household 2 occupant dickbutt2'
    , @HouseholdId = 2
	  , @EnteredBy = 'SbYFUv0fO8VLzotVFcTUn9uzhB02'
                