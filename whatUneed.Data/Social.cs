﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Data
{
    public enum SocialCategory { Stress = 1, Depression, Anxiety, Family, }
    public enum SocialResource { App = 1, Book, Website, Other }
    public class Social
    {
        [Key]
        public int SocialId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public SocialCategory CategoryType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public SocialResource ResourceType { get; set; }

        [Required]
        public string Description { get; set; }

        public string Url { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}