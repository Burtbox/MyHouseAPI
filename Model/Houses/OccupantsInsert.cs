using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
    public class OccupantInsert {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public int HouseholdId { get; set; }
    }
}
