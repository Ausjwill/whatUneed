using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Emotional
{
    public class EmotionalListItem
    {
        public int EmotionalId { get; set; }

        [Display(Name = "Category")]
        public Category CategoryType { get; set; }

        public string Title { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
