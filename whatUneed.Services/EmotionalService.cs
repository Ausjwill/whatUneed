using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;
using whatUneed.Models.Emotional;

namespace whatUneed.Services
{
    public class EmotionalService
    {
        private readonly Guid _userId;

        public EmotionalService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmotional(EmotionalCreate model)
        {
            var entity =
                new Emotional()
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
                ctx.Emotionals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmotionalListItem> GetEmotionals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Emotionals
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EmotionalListItem
                                {
                                    EmotionalId = e.EmotionalId,
                                    CategoryType = e.CategoryType,
                                    Title = e.Title,
                                    ResourceType = e.ResourceType,
                                    Url = e.Url
                                }
                        );

                return query.ToArray();
            }
        }

        public EmotionalDetail GetEmotionalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emotionals
                        .Single(e => e.EmotionalId == id && e.OwnerId == _userId);
                return
                    new EmotionalDetail
                    {
                        EmotionalId = entity.EmotionalId,
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

        public bool UpdateEmotional(EmotionalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emotionals
                        .Single(e => e.EmotionalId == model.EmotionalId && e.OwnerId == _userId);
                entity.CategoryType = model.CategoryType;
                entity.Title = model.Title;
                entity.ResourceType = model.ResourceType;
                entity.Description = model.Description;
                entity.Url = model.Url;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmotional(int emotionalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emotionals
                        .Single(e => e.EmotionalId == emotionalId && e.OwnerId == _userId);

                ctx.Emotionals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
