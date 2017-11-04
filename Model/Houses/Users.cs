using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
    public class User {
        [Key]
        [Required (ErrorMessage = "User Id is required.")]
        [StringLength (36, ErrorMessage = "The User Id can't exceed 36 characters.")]
        public string UserId { get; set; }

        [Required (ErrorMessage = "A display name is required.")]
        [StringLength (100, ErrorMessage = "Your display name can't exceed 100 characters.")]
        public string DisplayName { get; set; }
        
        [Required (ErrorMessage = "A household Id is required.")]
        public int HouseholdId { get; set; }
    }
}
