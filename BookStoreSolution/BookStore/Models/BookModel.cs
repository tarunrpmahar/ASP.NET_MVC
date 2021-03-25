using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength =5)]
        [Required(ErrorMessage ="Please enter the title of yuor book")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 5)]
        public string Description { get; set; }
        
        public string Category { get; set; }
        
        [Required(ErrorMessage ="Please choose the language of book")]
        public string Language { get; set; }

        [Display(Name = "Total Pages of Book")]
        [Required(ErrorMessage ="please enter the total pages")]
        public int? TotalPages { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }
    }
}
