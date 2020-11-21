﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Social
{
    public class SocialEdit
    {
        public int SocialId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Category")]
        [Display(Name = "Category")]
        public SocialCategory CategoryType { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select Resource Type")]
        [Display(Name = "Resource Type")]
        public SocialResource ResourceType { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        [Url]
        [Display(Name = "URL https://example.com")]
        public string Url { get; set; }
    }
}