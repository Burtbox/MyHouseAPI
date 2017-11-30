using System;
using System.ComponentModel.DataAnnotations;

namespace MyHouseAPI.Model {
    public class Lists {
        [Key]
        [Required (ErrorMessage = "List id is required.")]
        public int ListId { get; set; }

        [Required (ErrorMessage = "List name is required.")]
        [StringLength (400, ErrorMessage = "List name can't exceed 400 characters.")]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        [Required (ErrorMessage = "Complete is required.")]
        public DateTime Complete { get; set; }

        public DateTime DateCompleted { get; set; }
    }
}
