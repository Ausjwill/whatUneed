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
        readonly List<SocialListItem> searchResults = new List<SocialListItem>();

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
                    Url = model.Url,
                    InPerson = model.InPerson,
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
                                    Url = e.Url,
                                    InPerson = e.InPerson
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
                        Url = entity.Url,
                        InPerson = entity.InPerson,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public List<SocialListItem> GetSocialByCategory(string category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var socials = ctx.Socials.Where(e => e.CategoryType.Equals(category)).ToList();
                foreach (var social in socials)
                {
                    var foundSocial = new SocialListItem
                    {
                        SocialId = social.SocialId,
                        CategoryType = social.CategoryType,
                        Title = social.Title,
                        ResourceType = social.ResourceType,
                        Url = social.Url,
                        InPerson = social.InPerson
                    };
                    searchResults.Add(foundSocial);
                }
                return searchResults;
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
                entity.Url = model.Url;
                entity.InPerson = model.InPerson;
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
