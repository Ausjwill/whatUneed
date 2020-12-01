using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Favorites
{
    public class FavoritesListItem
    {
        [Key]
        public int FavoriteId { get; set; }

        public int? EmotionalId { get; set; }

        public int? PhysicalId { get; set; }

        public int? SocialId { get; set; }

        public int? FinancialId { get; set; }
    }
}
