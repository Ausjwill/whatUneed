﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;

namespace whatUneed.Models.Financial
{
    public class FinancialDetail
    {
        public int FinancialId { get; set; }

        [Display(Name = "Category")]
        public FinancialCategory CategoryType { get; set; }

        public string Title { get; set; }

        [Display(Name = "Resource Type")]
        public Resource ResourceType { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public State State { get; set; }

        [Display(Name = "In Person")]
        public bool InPerson { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
