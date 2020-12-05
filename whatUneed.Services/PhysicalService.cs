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
                    City = model.City,
                    State = model.State,
                    InPerson = model.InPerson,
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
                        .Select(
                            e =>
                                new PhysicalListItem
                                {
                                    PhysicalId = e.PhysicalId,
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

        public PhysicalDetail GetPhysicalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Physicals
                        .Single(e => e.PhysicalId == id);
                return
                    new PhysicalDetail
                    {
                        PhysicalId = entity.PhysicalId,
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

        public IEnumerable<PhysicalListItem> GetPhysicalByCategory(PhysicalCategory category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var categories =
                    ctx
                        .Physicals
                        .Where(e => e.CategoryType == category)
                        .Select(
                            e =>
                                new PhysicalListItem
                                {
                                    PhysicalId = e.PhysicalId,
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

        public IEnumerable<PhysicalListItem> GetPhysicalByResource(Resource resource)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Physicals
                        .Where(e => e.ResourceType == resource)
                        .Select(
                            e =>
                                new PhysicalListItem
                                {
                                    PhysicalId = e.PhysicalId,
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

        public IEnumerable<PhysicalListItem> GetPhysicalByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Physicals
                        .Where(e => e.Title.Contains(title))
                        .Select(
                            e =>
                                new PhysicalListItem
                                {
                                    PhysicalId = e.PhysicalId,
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

        public IEnumerable<PhysicalListItem> GetPhysicalByUrl(string url)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Physicals
                        .Where(e => e.Url.Contains(url))
                        .Select(
                            e =>
                                new PhysicalListItem
                                {
                                    PhysicalId = e.PhysicalId,
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

        public IEnumerable<PhysicalListItem> GetPhysicalByInPerson()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Physicals
                        .Where(e => e.InPerson == true)
                        .Select(
                            e =>
                                new PhysicalListItem
                                {
                                    PhysicalId = e.PhysicalId,
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
                entity.City = model.City;
                entity.State = model.State;
                entity.InPerson = model.InPerson;
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
