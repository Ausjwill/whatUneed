using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Data
{
    public class Favorites
    {
        [Key]
        public int FavoriteId { get; set; }

        public Guid? OwnerId { get; set; }

        [ForeignKey(nameof(Emotional))]
        public int? EmotionalId { get; set; }
        public virtual Emotional Emotional { get; set; }


        [ForeignKey(nameof(Physical))]
        public int? PhysicalId { get; set; }
        public virtual Physical Physical { get; set; }


        [ForeignKey(nameof(Social))]
        public int? SocialId { get; set; }
        public virtual Social Social { get; set; }


        [ForeignKey(nameof(Financial))]
        public int? FinancialId { get; set; }
        public virtual Financial Financial { get; set; }

        public bool AddToFavorites { get; set; }
    }
}
