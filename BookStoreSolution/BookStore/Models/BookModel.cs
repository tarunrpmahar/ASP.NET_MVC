using BookStore.Enums;
using BookStore.Helpers;
using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage ="Please Enter the title of your book")]
        //[MyCustomValidation] coming from using BookStore.Helpers;
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 5)]
        public string Description { get; set; }
        
        public string Category { get; set; }
        
        [Display(Name ="Language")]
        [Required(ErrorMessage ="Please Choose the language of book")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        //[Required(ErrorMessage = "Please choose the language of book")]
        //public LanguageEnums LanguageEnum { get; set; }

        [Display(Name = "Total Pages of Book")]
        [Required(ErrorMessage ="please enter the total pages")]
        public int? TotalPages { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }

        [Display(Name ="Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery image of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }

        public string BookPdfUrl { get; set; }
    }   
}
