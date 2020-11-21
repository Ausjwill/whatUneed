﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Physical
{
    public class PhysicalListItem
    {
        public int PhysicalId { get; set; }

        [Display(Name = "Category")]
        public PhysicalCategory CategoryType { get; set; }

        public string Title { get; set; }

        [Display(Name = "Resource Type")]
        public PhysicalResource ResourceType { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }
    }
}