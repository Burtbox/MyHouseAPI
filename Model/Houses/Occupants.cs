using System.ComponentModel.DataAnnotations;

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
    }
}
