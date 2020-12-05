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
                    City = model.City,
                    State = model.State,
                    InPerson = model.InPerson,
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
                        .Select(
                            e =>
                                new FinancialListItem
                                {
                                    FinancialId = e.FinancialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    Url = e.Url,
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
                        .Single(e => e.FinancialId == id);
                return
                    new FinancialDetail
                    {
                        FinancialId = entity.FinancialId,
                        CategoryType = entity.CategoryType,
                        Title = entity.Title,
                        ResourceType = entity.ResourceType,
                        Description = entity.Description,
                        City = entity.City,
                        State = entity.State,
                        InPerson = entity.InPerson,
                        Url = entity.Url,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public IEnumerable<FinancialListItem> GetFinancialByCategory(FinancialCategory category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var categories =
                    ctx
                        .Financials
                        .Where(e => e.CategoryType == category)
                        .Select(
                            e =>
                                new FinancialListItem
                                {
                                    FinancialId = e.FinancialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    Url = e.Url,
                                }
                        );

                return categories.ToArray();
            }
        }

        public IEnumerable<FinancialListItem> GetFinancialByResource(Resource resource)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Financials
                        .Where(e => e.ResourceType == resource)
                        .Select(
                            e =>
                                new FinancialListItem
                                {
                                    FinancialId = e.FinancialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
            }
        }

        public IEnumerable<FinancialListItem> GetFinancialByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Financials
                        .Where(e => e.Title.Contains(title))
                        .Select(
                            e =>
                                new FinancialListItem
                                {
                                    FinancialId = e.FinancialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
            }
        }

        public IEnumerable<FinancialListItem> GetFinancialByUrl(string url)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Financials
                        .Where(e => e.Url.Contains(url))
                        .Select(
                            e =>
                                new FinancialListItem
                                {
                                    FinancialId = e.FinancialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
            }
        }

        public IEnumerable<FinancialListItem> GetFinancialByInPerson()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Financials
                        .Where(e => e.InPerson == true)
                        .Select(
                            e =>
                                new FinancialListItem
                                {
                                    FinancialId = e.FinancialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
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
                entity.City = model.City;
                entity.State = model.State;
                entity.InPerson = model.InPerson;
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
