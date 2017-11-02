
using System;
using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
    public class ListItems {
        [Key]
        [Required (ErrorMessage = "List item id is required.")]
        public int ListItemId { get; set; }

        [Required (ErrorMessage = "List id is required.")]
        public int ListId { get; set; }

        [Required (ErrorMessage = "Ingredient id is required.")]
        public int IngredientId { get; set; }

        [Required (ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        [Required (ErrorMessage = "Complete is required.")]
        public Byte Complete { get; set; }
    }
}
