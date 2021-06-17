using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BookStore.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The Title field is Required")] 
        [StringLength(100,MinimumLength = 3)]
        public string Title { get; set; }
        [Required(ErrorMessage ="The Author Name is Required")]
        [StringLength(20, MinimumLength = 4)]
        public string Author { get; set; } 
        public string Description { get; set; }  
        public string Category { get; set; }
        [Required(ErrorMessage = "The Laguage field is Required")]
        public int LanguageId { get; set; }
        public string Language { get; set; } 

        [Required(ErrorMessage ="The total pages field is must be Required")]
        public int TotalPages { get; set; }  
    }
}
