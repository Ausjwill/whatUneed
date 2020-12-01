using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Models.Favorites
{
    public class FavoritesCreate
    {
        [Key]
        public int FavoriteId { get; set; }

        public int? EmotionalId { get; set; }

        public int? PhysicalId { get; set; }

        public int? SocialId { get; set; }

        public int? FinancialId { get; set; }
    }
}
