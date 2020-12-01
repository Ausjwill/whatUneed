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


        //EMOTIONAL
        public int? EmotionalId { get; set; }

        [Display(Name = "Category")]
        public EmotionalCategory EmotionalCategoryType { get; set; }

        public string EmotionalTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource EmotionalResourceType { get; set; }

        public string EmotionalCity { get; set; }

        public State EmotionalState { get; set; }

        [Display(Name = "In Person")]
        public bool? EmotionalInPerson { get; set; }

        [Display(Name = "Favorites")]
        public bool? EmotionalAddToFavorites { get; set; }

        [Display(Name = "URL")]
        public string EmotionalUrl { get; set; }


        //PHYSICAL
        public int? PhysicalId { get; set; }

        [Display(Name = "Category")]
        public PhysicalCategory PhysicalCategoryType { get; set; }

        public string PhysicalTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource PhysicalResourceType { get; set; }

        public string PhysicalCity { get; set; }

        public State PhysicalState { get; set; }

        [Display(Name = "In Person")]
        public bool? PhysicalInPerson { get; set; }

        [Display(Name = "Favorites")]
        public bool? PhysicalAddToFavorites { get; set; }

        [Display(Name = "URL")]
        public string PhysicalUrl { get; set; }


        //SOCIAL
        public int? SocialId { get; set; }
        [Display(Name = "Category")]
        public SocialCategory SocialCategoryType { get; set; }

        public string SocialTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource SocialResourceType { get; set; }

        public string SocialCity { get; set; }

        public State SocialState { get; set; }

        [Display(Name = "In Person")]
        public bool? SocialInPerson { get; set; }

        [Display(Name = "Favorites")]
        public bool? SocialAddToFavorites { get; set; }

        [Display(Name = "URL")]
        public string SocialUrl { get; set; }


        //FINANCIAL
        public int? FinancialId { get; set; }

        [Display(Name = "Category")]
        public FinancialCategory FinancialCategoryType { get; set; }
        public string FinancialTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource FinancialResourceType { get; set; }

        public string FinancialCity { get; set; }

        public State FinancialState { get; set; }

        [Display(Name = "In Person")]
        public bool? FinancialInPerson { get; set; }

        [Display(Name = "Favorites")]
        public bool? FinancialAddToFavorites { get; set; }

        [Display(Name = "URL")]
        public string FinancialUrl { get; set; }
    }
}
