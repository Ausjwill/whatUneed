using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatUneed.Data
{
    public enum FinancialCategory { Budgeting = 1, Saving, Debt, Support, Will_Trust }
    public class Financial
    {
        [Key]
        public int FinancialId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public FinancialCategory CategoryType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Resource ResourceType { get; set; }

        [Required]
        public string Description { get; set; }

        public string Url { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
