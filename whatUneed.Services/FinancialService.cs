using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;
using whatUneed.Models.Financial;

namespace whatUneed.Services
{
    public class FinancialService
    {
        private readonly Guid _userId;
        readonly List<FinancialListItem> searchResults = new List<FinancialListItem>();

        public FinancialService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFinancial(FinancialCreate model)
        {
            var entity =
                new Financial()
                {
                    OwnerId = _userId,
                    CategoryType = model.CategoryType,
                    Title = model.Title,
                    ResourceType = model.ResourceType,
                    Description = model.Description,
                    Url = model.Url,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Financials.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FinancialListItem> GetFinancials()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Financials
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FinancialListItem
                                {
                                    FinancialId = e.FinancialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    Url = e.Url
                                }
                        );

                return query.ToArray();
            }
        }

        public FinancialDetail GetFinancialById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Financials
                        .Single(e => e.FinancialId == id && e.OwnerId == _userId);
                return
                    new FinancialDetail
                    {
                        FinancialId = entity.FinancialId,
                        CategoryType = entity.CategoryType,
                        Title = entity.Title,
                        ResourceType = entity.ResourceType,
                        Description = entity.Description,
                        Url = entity.Url,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public List<FinancialListItem> GetFinancialByCategory(string category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var financials = ctx.Financials.Where(e => e.CategoryType.Equals(category)).ToList();
                foreach (var financial in financials)
                {
                    var foundFinancial = new FinancialListItem
                    {
                        FinancialId = financial.FinancialId,
                        CategoryType = financial.CategoryType,
                        Title = financial.Title,
                        ResourceType = financial.ResourceType,
                        Url = financial.Url,
                    };
                    searchResults.Add(foundFinancial);
                }
                return searchResults;
            }
        }

        public bool UpdateFinancial(FinancialEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Financials
                        .Single(e => e.FinancialId == model.FinancialId && e.OwnerId == _userId);
                entity.CategoryType = model.CategoryType;
                entity.Title = model.Title;
                entity.ResourceType = model.ResourceType;
                entity.Description = model.Description;
                entity.Url = model.Url;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFinancial(int financialId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Financials
                        .Single(e => e.FinancialId == financialId && e.OwnerId == _userId);

                ctx.Financials.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
