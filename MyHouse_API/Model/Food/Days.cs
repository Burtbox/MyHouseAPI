using System;
using System.ComponentModel.DataAnnotations;

namespace MyHouseAPI.Model.Food
{
    public class Days
    {
        [Key]
        [Required(ErrorMessage = "Date is required.")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Meal id is required.")]
        public int MealId { get; set; }

        public Byte NumberOfPeople { get; set; }
    }
}
