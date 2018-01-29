namespace MyHouseAPI.Model
{
    public abstract class HouseholdDetails
    {
        public string Name { get; set; }
    }

    public class Household : HouseholdDetails
    {
        public int HouseholdId { get; set; }
    }

    public class HouseholdInsert : HouseholdDetails
    {
        public string EnteredBy { get; set; }
    }

    public class HouseholdUpdate : Household
    {
        public string ModifiedBy { get; set; }
    }
}
