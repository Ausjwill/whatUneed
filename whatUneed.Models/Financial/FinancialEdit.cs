using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Financial
{
    public class FinancialEdit
    {
        public int FinancialId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Category")]
        [Display(Name = "Category")]
        public FinancialCategory CategoryType { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Resource Type")]
        [Display(Name = "Resource Type")]
        public Resource ResourceType { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        public string City { get; set; }

        public State State { get; set; }

        [Display(Name = "In Person")]
        public bool InPerson { get; set; }

        [Display(Name = "Add To Favorites")]
        public bool AddToFavorites { get; set; }

        [Url]
        [Display(Name = "URL https://example.com")]
        public string Url { get; set; }
    }
}
