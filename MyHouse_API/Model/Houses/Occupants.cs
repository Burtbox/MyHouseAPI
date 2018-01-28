namespace MyHouseAPI.Model
{
    public class OccupantDetails
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public int HouseholdId { get; set; }
    }

    public class OccupantInsert : OccupantDetails
    {
        public string EnteredBy { get; set; }
    }

    public class OccupantUpdate : Occupant
    {
        public string ModifiedBy { get; set; }
    }

    public class Occupant : OccupantDetails
    {
        public int OccupantId { get; set; }

    }
}
