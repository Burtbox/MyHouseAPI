namespace MyHouseAPI.Model
{
    public class HouseholdName
    {
        public string Name { get; set; }
    }

    public class Household : HouseholdName
    {
        public int HouseholdId { get; set; }
    }

    public class HouseholdInsert : HouseholdName
    {
        public string EnteredBy { get; set; }
    }

    public class HouseholdUpdate : Household
    {
        public string ModifiedBy { get; set; }
    }
}
