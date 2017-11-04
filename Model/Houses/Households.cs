using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
    public class Household {
        [Key]
        [Required (ErrorMessage = "Household id is required.")]
        public string HouseholdId { get; set; }

        [Required (ErrorMessage = "Household id is required.")]
        [StringLength (100, ErrorMessage = "The household name can't exceed 36 characters.")]
        public string Name { get; set; }
    }
}
