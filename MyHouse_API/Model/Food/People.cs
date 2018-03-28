using System;
using System.ComponentModel.DataAnnotations;

namespace MyHouseAPI.Model.Food
{
    public class People
    {
        [Key]
        [Required(ErrorMessage = "Person id is required.")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Attendee's name is required.")]
        [StringLength(200, ErrorMessage = "Attendee's name can't exceed 200 characters.")]
        public string Person { get; set; }
    }
}
