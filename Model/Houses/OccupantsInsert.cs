using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
    public class OccupantInsert {
        [StringLength (36, ErrorMessage = "The User Id can't exceed 36 characters.")]
        public string UserId { get; set; }

        [Required (ErrorMessage = "A display name is required.")]
        [StringLength (100, ErrorMessage = "Your display name can't exceed 100 characters.")]
        public string DisplayName { get; set; }
        public int HouseholdId { get; set; }
    }
}
