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
        public EmotionalCategory? EmotionalCategoryType { get; set; }

        [Display(Name = "Title")]
        public string EmotionalTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource? EmotionalResourceType { get; set; }

        [Display(Name = "City")]
        public string EmotionalCity { get; set; }

        [Display(Name = "State")]
        public State? EmotionalState { get; set; }

        [Display(Name = "In Person")]
        public bool? EmotionalInPerson { get; set; }

        [Display(Name = "URL")]
        public string EmotionalUrl { get; set; }



        //PHYSICAL
        public int? PhysicalId { get; set; }

        [Display(Name = "Category")]
        public PhysicalCategory? PhysicalCategoryType { get; set; }

        [Display(Name = "Title")]
        public string PhysicalTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource? PhysicalResourceType { get; set; }

        [Display(Name = "City")]
        public string PhysicalCity { get; set; }

        [Display(Name = "State")]
        public State? PhysicalState { get; set; }

        [Display(Name = "In Person")]
        public bool? PhysicalInPerson { get; set; }

        [Display(Name = "URL")]
        public string PhysicalUrl { get; set; }



        //SOCIAL
        public int? SocialId { get; set; }

        [Display(Name = "Category")]
        public SocialCategory? SocialCategoryType { get; set; }

        [Display(Name = "Title")]
        public string SocialTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource? SocialResourceType { get; set; }

        [Display(Name = "City")]
        public string SocialCity { get; set; }

        [Display(Name = "State")]
        public State? SocialState { get; set; }

        [Display(Name = "In Person")]
        public bool? SocialInPerson { get; set; }

        [Display(Name = "URL")]
        public string SocialUrl { get; set; }



        //FINANCIAL
        public int? FinancialId { get; set; }

        [Display(Name = "Category")]
        public FinancialCategory? FinancialCategoryType { get; set; }

        [Display(Name = "Title")]
        public string FinancialTitle { get; set; }

        [Display(Name = "Resource Type")]
        public Resource? FinancialResourceType { get; set; }

        [Display(Name = "City")]
        public string FinancialCity { get; set; }

        [Display(Name = "State")]
        public State? FinancialState { get; set; }

        [Display(Name = "In Person")]
        public bool? FinancialInPerson { get; set; }

        [Display(Name = "URL")]
        public string FinancialUrl { get; set; }
    }
}
