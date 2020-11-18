using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Data
{
    public enum Category { Stress = 1, Depression, Anxiety, Family, }
    public enum Resource { App = 1, Book, Website, Other}
    public class Emotional
    {
        [Key]
        public int EmotionalId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Category CategoryType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Resource ResourceType { get; set; }

        [Required]
        public string Description { get; set; }

        public UrlAttribute Url { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
