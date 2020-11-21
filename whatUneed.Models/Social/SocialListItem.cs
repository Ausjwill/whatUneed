using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Social
{
    public class SocialListItem
    {
        public int SocialId { get; set; }

        [Display(Name = "Category")]
        public SocialCategory CategoryType { get; set; }

        public string Title { get; set; }

        [Display(Name = "Resource Type")]
        public SocialResource ResourceType { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }
    }
}
