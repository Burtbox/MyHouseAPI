namespace MyHouseAPI.Model.Houses
{
    public abstract class HouseholdDetails
    {
        public string Name { get; set; }
    }

    public abstract class Household : HouseholdDetails
    {
        public int OccupantId { get; set; }
    }

    public class HouseholdResponse : Household
    {
        public bool InviteAccepted { get; set; }
    }

    public class HouseholdInsertRequest : HouseholdDetails
    {
        public string EnteredBy { get; set; }
        public string CreatorDisplayName { get; set; }
    }

    public class HouseholdUpdateRequest : Household
    {
        public string ModifiedBy { get; set; }
    }
}
