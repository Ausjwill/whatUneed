using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;
using whatUneed.Models.Physical;

namespace whatUneed.Services
{
    public class PhysicalService
    {
        private readonly Guid _userId;
        readonly List<PhysicalListItem> searchResults = new List<PhysicalListItem>();

        public PhysicalService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePhysical(PhysicalCreate model)
        {
            var entity =
                new Physical()
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
                ctx.Physicals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PhysicalListItem> GetPhysicals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Physicals
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PhysicalListItem
                                {
                                    PhysicalId = e.PhysicalId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    Url = e.Url
                                }
                        );

                return query.ToArray();
            }
        }

        public PhysicalDetail GetPhysicalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Physicals
                        .Single(e => e.PhysicalId == id && e.OwnerId == _userId);
                return
                    new PhysicalDetail
                    {
                        PhysicalId = entity.PhysicalId,
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

        public List<PhysicalListItem> GetPhysicalByCategory(string category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var physicals = ctx.Physicals.Where(e => e.CategoryType.Equals(category)).ToList();
                foreach (var physical in physicals)
                {
                    var foundPhysical = new PhysicalListItem
                    {
                        PhysicalId = physical.PhysicalId,
                        CategoryType = physical.CategoryType,
                        Title = physical.Title,
                        ResourceType = physical.ResourceType,
                        Url = physical.Url,
                    };
                    searchResults.Add(foundPhysical);
                }
                return searchResults;
            }
        }

        public bool UpdatePhysical(PhysicalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Physicals
                        .Single(e => e.PhysicalId == model.PhysicalId && e.OwnerId == _userId);
                entity.CategoryType = model.CategoryType;
                entity.Title = model.Title;
                entity.ResourceType = model.ResourceType;
                entity.Description = model.Description;
                entity.Url = model.Url;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePhysical(int physicalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Physicals
                        .Single(e => e.PhysicalId == physicalId && e.OwnerId == _userId);

                ctx.Physicals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
