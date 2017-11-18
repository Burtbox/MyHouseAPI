using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
    public class Occupant : OccupantInsert {
        public int OccupantId { get; set; }
    }
}
