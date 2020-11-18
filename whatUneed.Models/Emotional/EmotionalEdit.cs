using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Emotional
{
    public class EmotionalEdit
    {
        public int EmotionalId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select Category")]
        [Display(Name = "Category")]
        public Category CategoryType { get; set; }

        public string Title { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select Resource Type")]
        [Display(Name = "Resource Type")]
        public Resource ResourceType { get; set; }

        public string Description { get; set; }

        public UrlAttribute Url { get; set; }
    }
}
