namespace MyHouseAPI.Model
{
    public class Occupant : OccupantInsert
    {
        public int OccupantId { get; set; }
    }

    public class OccupantInsert
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public int HouseholdId { get; set; }
        public string EnteredBy { get; set; }
    }

    public class OccupantUpdate: Occupant // TODO: ED! split up your models into data and view models! - atm too mungey
    {
        public string ModifiedBy { get; set; }
    }
}
