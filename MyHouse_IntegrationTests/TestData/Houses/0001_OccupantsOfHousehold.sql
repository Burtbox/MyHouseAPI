exec houses.Households_Insert 
	  @Name = 'Household 1 owner dickbutt'
	, @EnteredBy = '70ajxWmrS6XIU53GL6bj1VcjCsm1'
	, @CreatorDisplayName = 'dickbutt'

exec houses.Households_Insert 
	  @Name = 'Household 2 owner dickbutt2'
	, @EnteredBy = 'SbYFUv0fO8VLzotVFcTUn9uzhB02'
	, @CreatorDisplayName = 'dickbutt2'

exec houses.Occupants_Insert 
      @UserId = 'zzrmi1i7nsApSvmeqA9QSIx1zwfs'
    , @DisplayName = 'Household 1 occupant O2DispName'
    , @OccupantId = 1
	  , @EnteredBy = '70ajxWmrS6XIU53GL6bj1VcjCsm1'

-- Add user outside of queried household
exec houses.Occupants_Insert 
	  @UserId = 'zzrmi1i7nsApSvmeqA9QSIx1zwfs'
    , @DisplayName = 'Household 2 occupant O2DispName'
    , @OccupantId = 2
	  , @EnteredBy = 'SbYFUv0fO8VLzotVFcTUn9uzhB02'
                