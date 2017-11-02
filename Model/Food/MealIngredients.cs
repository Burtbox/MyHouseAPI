using System;
using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
    public class MealIngredients {
        [Key]
        [Required (ErrorMessage = "Meal ingredient id is required.")]
        public int MealIngredientId { get; set; }

        [Required (ErrorMessage = "Meal id is required.")]
        public int MealId { get; set; }

        [Required (ErrorMessage = "Ingredient id is required.")]
        public int IngredientId { get; set; }

        [Required (ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }
    }
}
