namespace MyHouseAPI.Model
{
    public abstract class HouseholdDetails
    {
        public string Name { get; set; }
    }

    public abstract class Household : HouseholdDetails
    {
        public int HouseholdId { get; set; }
    }

    public class HouseholdResponse : Household { }

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
