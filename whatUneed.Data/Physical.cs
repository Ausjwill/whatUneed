using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Data
{
    public enum PhysicalCategory { Strength = 1, Endurance, Flexibility, Pampering }
    public class Physical
    {
        [Key]
        public int PhysicalId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public PhysicalCategory CategoryType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Resource ResourceType { get; set; }

        [Required]
        public string Description { get; set; }

        public string Url { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
