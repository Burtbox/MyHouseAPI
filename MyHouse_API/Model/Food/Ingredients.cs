using System.ComponentModel.DataAnnotations;

namespace MyHouseAPI.Model.Food
{
    public class Ingredients
    {
        [Key]
        [Required(ErrorMessage = "Ingredient id is required.")]
        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Ingredient name is required.")]
        [StringLength(400, ErrorMessage = "Ingredient name can't exceed 400 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Units are required.")]
        [StringLength(40, ErrorMessage = "Units can't exceed 40 characters.")]
        public string Units { get; set; }
    }
}
