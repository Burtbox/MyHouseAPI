using System.ComponentModel.DataAnnotations;

namespace MyHouseAPI.Model
{
    public class Meals {
        [Key]
        [Required (ErrorMessage = "Meal id is required.")]
        public int MealId { get; set; }

        [Required (ErrorMessage = "Meal name is required.")]
        [StringLength (400, ErrorMessage = "Ingredient name can't exceed 400 characters.")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Category is required.")]
        [StringLength (400, ErrorMessage = "Category can't exceed 40 characters.")]
        public string Category { get; set; }
    }
}
