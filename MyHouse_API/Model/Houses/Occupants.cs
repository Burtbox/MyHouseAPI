namespace MyHouseAPI.Model.Houses
{
    public abstract class OccupantDetails
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public bool InviteStatus { get; set; }
    }

    public abstract class Occupant : OccupantDetails
    {
        public int OccupantId { get; set; }
    }

    public class OccupantResponse : Occupant { }


    public class OccupantInsertRequest : Occupant
    {
        public string EnteredBy { get; set; }
    }

    public class OccupantUpdateRequest : Occupant
    {

    }
}
