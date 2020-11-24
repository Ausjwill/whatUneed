using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;
using whatUneed.Models.Social;

namespace whatUneed.Services
{
    public class SocialService
    {
        private readonly Guid _userId;

        public SocialService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSocial(SocialCreate model)
        {
            var entity =
                new Social()
                {
                    OwnerId = _userId,
                    CategoryType = model.CategoryType,
                    Title = model.Title,
                    ResourceType = model.ResourceType,
                    Description = model.Description,
                    City = model.City,
                    State = model.State,
                    InPerson = model.InPerson,
                    AddToFavorites = model.AddToFavorites,
                    Url = model.Url,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Socials.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SocialListItem> GetSocials()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Socials
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SocialListItem
                                {
                                    SocialId = e.SocialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    AddToFavorites = e.AddToFavorites,
                                    Url = e.Url,
                                }
                        );

                return query.ToArray();
            }
        }

        public SocialDetail GetSocialById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Socials
                        .Single(e => e.SocialId == id && e.OwnerId == _userId);
                return
                    new SocialDetail
                    {
                        SocialId = entity.SocialId,
                        CategoryType = entity.CategoryType,
                        Title = entity.Title,
                        ResourceType = entity.ResourceType,
                        Description = entity.Description,
                        City = entity.City,
                        State = entity.State,
                        InPerson = entity.InPerson,
                        AddToFavorites = entity.AddToFavorites,
                        Url = entity.Url,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public IEnumerable<SocialListItem> GetSocialByCategory(SocialCategory category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var categories =
                    ctx
                        .Socials
                        .Where(e => e.CategoryType == category)
                        .Select(
                            e =>
                                new SocialListItem
                                {
                                    SocialId = e.SocialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    AddToFavorites = e.AddToFavorites,
                                    Url = e.Url,
                                }
                        );

                return categories.ToArray();
            }
        }

        public IEnumerable<SocialListItem> GetSocialByResource(Resource resource)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Socials
                        .Where(e => e.ResourceType == resource)
                        .Select(
                            e =>
                                new SocialListItem
                                {
                                    SocialId = e.SocialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    AddToFavorites = e.AddToFavorites,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
            }
        }

        public IEnumerable<SocialListItem> GetSocialByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Socials
                        .Where(e => e.Title.Contains(title))
                        .Select(
                            e =>
                                new SocialListItem
                                {
                                    SocialId = e.SocialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    AddToFavorites = e.AddToFavorites,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
            }
        }

        public IEnumerable<SocialListItem> GetSocialByUrl(string url)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Socials
                        .Where(e => e.Url.Contains(url))
                        .Select(
                            e =>
                                new SocialListItem
                                {
                                    SocialId = e.SocialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    AddToFavorites = e.AddToFavorites,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
            }
        }

        public IEnumerable<SocialListItem> GetSocialByInPerson()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resources =
                    ctx
                        .Socials
                        .Where(e => e.InPerson == true)
                        .Select(
                            e =>
                                new SocialListItem
                                {
                                    SocialId = e.SocialId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    City = e.City,
                                    State = e.State,
                                    InPerson = e.InPerson,
                                    AddToFavorites = e.AddToFavorites,
                                    Url = e.Url,
                                }
                        );

                return resources.ToArray();
            }
        }

        public bool UpdateSocial(SocialEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Socials
                        .Single(e => e.SocialId == model.SocialId && e.OwnerId == _userId);
                entity.CategoryType = model.CategoryType;
                entity.Title = model.Title;
                entity.ResourceType = model.ResourceType;
                entity.Description = model.Description;
                entity.City = model.City;
                entity.State = model.State;
                entity.InPerson = model.InPerson;
                entity.AddToFavorites = model.AddToFavorites;
                entity.Url = model.Url;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSocial(int socialId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Socials
                        .Single(e => e.SocialId == socialId && e.OwnerId == _userId);

                ctx.Socials.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
