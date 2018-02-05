namespace MyHouseAPI.Model
{
    public abstract class OccupantDetails
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public int HouseholdId { get; set; }
    }

    public abstract class Occupant : OccupantDetails
    {
        public int OccupantId { get; set; }
    }

    public class OccupantResponse : Occupant { }


    public class OccupantInsertRequest : OccupantDetails
    {
        public string EnteredBy { get; set; }
    }

    public class OccupantUpdateRequest : Occupant { }
}
