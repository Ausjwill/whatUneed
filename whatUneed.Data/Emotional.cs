using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Data
{
    public enum EmotionalCategory { Stress = 1, Depression, Anxiety, Family, Relationships }
    public enum Resource { App = 1, Book, Website, Suggestion, Podcast, Video, Other }
    public enum State { AL = 1, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UR, VT, VA, WA, WV, WI, WY }
    public class Emotional
    {
        [Key]
        public int EmotionalId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public EmotionalCategory CategoryType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Resource ResourceType { get; set; }

        [Required]
        public string Description { get; set; }

        public string City { get; set; }

        public State State { get; set; }

        public bool InPerson { get; set; }

        public bool AddToFavorites { get; set; }

        public string Url { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
    }
}
