using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Data
{
    public enum SocialCategory { Sports = 1, Community, Hobbies, Charity, Family, Events }
    public class Social
    {
        [Key]
        public int SocialId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public SocialCategory CategoryType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Resource ResourceType { get; set; }

        [Required]
        public string Description { get; set; }

        public string Url { get; set; }

        public bool InPerson { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
