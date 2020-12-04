using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatUneed.Data;
using whatUneed.Models.Favorites;

namespace whatUneed.Services
{
    public class FavoritesService
    {
        private readonly Guid _userId;

        public FavoritesService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFavorites(FavoritesCreate model)
        {
            var entity =
                new Favorites()
                {
                    OwnerId = _userId,
                    EmotionalId = model.EmotionalId,
                    PhysicalId = model.PhysicalId,
                    SocialId = model.SocialId,
                    FinancialId = model.FinancialId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (model.EmotionalId != null)
                    {
                        var checkForFavorite = ctx.Favorites.Single(e => e.EmotionalId == entity.EmotionalId && e.OwnerId == _userId);
                    }
                    if (model.PhysicalId != null)
                    {
                        var checkForFavorite = ctx.Favorites.Single(e => e.PhysicalId == entity.PhysicalId && e.OwnerId == _userId);
                    }
                    if (model.SocialId != null)
                    {
                        var checkForFavorite = ctx.Favorites.Single(e => e.SocialId == entity.SocialId && e.OwnerId == _userId);
                    }
                    if (model.FinancialId != null)
                    {
                        var checkForFavorite = ctx.Favorites.Single(e => e.FinancialId == entity.FinancialId && e.OwnerId == _userId);
                    }

                    return false;
                }
                catch { }
                ctx.Favorites.Add(entity);
                ctx.SaveChanges();
                return true;
            }
        }

        public IEnumerable<FavoritesListItem> GetFavorites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Favorites
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FavoritesListItem
                                {
                                    FavoriteId = e.FavoriteId,

                                    //EMOTIONAL
                                    EmotionalId = e.EmotionalId,
                                    EmotionalCategoryType = e.Emotional.CategoryType,
                                    EmotionalTitle = e.Emotional.Title,
                                    EmotionalResourceType = e.Emotional.ResourceType,
                                    EmotionalCity = e.Emotional.City,
                                    EmotionalState = e.Emotional.State,
                                    EmotionalInPerson = e.Emotional.InPerson,
                                    EmotionalUrl = e.Emotional.Url,

                                    //PHYSICAL
                                    PhysicalId = e.PhysicalId,
                                    PhysicalCategoryType = e.Physical.CategoryType,
                                    PhysicalTitle = e.Physical.Title,
                                    PhysicalResourceType = e.Physical.ResourceType,
                                    PhysicalCity = e.Physical.City,
                                    PhysicalState = e.Physical.State,
                                    PhysicalInPerson = e.Physical.InPerson,
                                    PhysicalUrl = e.Physical.Url,

                                    //SOCIAL
                                    SocialId = e.SocialId,
                                    SocialCategoryType = e.Social.CategoryType,
                                    SocialTitle = e.Social.Title,
                                    SocialResourceType = e.Social.ResourceType,
                                    SocialCity = e.Social.City,
                                    SocialState = e.Social.State,
                                    SocialInPerson = e.Social.InPerson,
                                    SocialUrl = e.Social.Url,

                                    //FINANCIAL
                                    FinancialId = e.FinancialId,
                                    FinancialCategoryType = e.Financial.CategoryType,
                                    FinancialTitle = e.Financial.Title,
                                    FinancialResourceType = e.Financial.ResourceType,
                                    FinancialCity = e.Financial.City,
                                    FinancialState = e.Financial.State,
                                    FinancialInPerson = e.Financial.InPerson,
                                    FinancialUrl = e.Financial.Url,
                                }
                        );

                return query.ToArray();
            }
        }

        public FavoritesDetail GetFavoritesByEmotionalId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.EmotionalId == id);
                return
                    new FavoritesDetail
                    {
                        FavoriteId = entity.FavoriteId,
                        EmotionalId = entity.EmotionalId,
                        EmotionalCategoryType = entity.Emotional.CategoryType,
                        EmotionalTitle = entity.Emotional.Title,
                        EmotionalResourceType = entity.Emotional.ResourceType,
                        EmotionalDescription = entity.Emotional.Description,
                        EmotionalCity = entity.Emotional.City,
                        EmotionalState = entity.Emotional.State,
                        EmotionalInPerson = entity.Emotional.InPerson,
                        EmotionalUrl = entity.Emotional.Url,
                        EmotionalCreatedUtc = entity.Emotional.CreatedUtc,
                        EmotionalModifiedUtc = entity.Emotional.ModifiedUtc,
                    };
            }
        }

        public FavoritesDetail GetFavoritesByPhysicalId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.PhysicalId == id);
                return
                    new FavoritesDetail
                    {
                        FavoriteId = entity.FavoriteId,
                        PhysicalId = entity.PhysicalId,
                        PhysicalCategoryType = entity.Physical.CategoryType,
                        PhysicalTitle = entity.Physical.Title,
                        PhysicalResourceType = entity.Physical.ResourceType,
                        PhysicalDescription = entity.Physical.Description,
                        PhysicalCity = entity.Physical.City,
                        PhysicalState = entity.Physical.State,
                        PhysicalInPerson = entity.Physical.InPerson,
                        PhysicalUrl = entity.Physical.Url,
                        PhysicalCreatedUtc = entity.Physical.CreatedUtc,
                        PhysicalModifiedUtc = entity.Physical.ModifiedUtc,
                    };
            }
        }

        public FavoritesDetail GetFavoritesBySocialId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.SocialId == id);
                return
                    new FavoritesDetail
                    {
                        FavoriteId = entity.FavoriteId,
                        SocialId = entity.SocialId,
                        SocialCategoryType = entity.Social.CategoryType,
                        SocialTitle = entity.Social.Title,
                        SocialResourceType = entity.Social.ResourceType,
                        SocialDescription = entity.Social.Description,
                        SocialCity = entity.Social.City,
                        SocialState = entity.Social.State,
                        SocialInPerson = entity.Social.InPerson,
                        SocialUrl = entity.Social.Url,
                        SocialCreatedUtc = entity.Social.CreatedUtc,
                        SocialModifiedUtc = entity.Social.ModifiedUtc,
                    };
            }
        }

        public FavoritesDetail GetFavoritesByFinancialId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.FinancialId == id);
                return
                    new FavoritesDetail
                    {
                        FavoriteId = entity.FavoriteId,
                        FinancialId = entity.FinancialId,
                        FinancialCategoryType = entity.Financial.CategoryType,
                        FinancialTitle = entity.Financial.Title,
                        FinancialResourceType = entity.Financial.ResourceType,
                        FinancialDescription = entity.Financial.Description,
                        FinancialCity = entity.Financial.City,
                        FinancialState = entity.Financial.State,
                        FinancialInPerson = entity.Financial.InPerson,
                        FinancialUrl = entity.Financial.Url,
                        FinancialCreatedUtc = entity.Financial.CreatedUtc,
                        FinancialModifiedUtc = entity.Financial.ModifiedUtc,
                    };
            }
        }

        public IEnumerable<FavoritesListItem> GetFavoritesByEmotional()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Favorites
                        .Where(e => e.OwnerId == _userId && e.EmotionalId != null)
                        .Select(
                            e =>
                                new FavoritesListItem
                                {
                                    FavoriteId = e.FavoriteId,
                                    EmotionalId = e.EmotionalId,
                                    EmotionalCategoryType = e.Emotional.CategoryType,
                                    EmotionalTitle = e.Emotional.Title,
                                    EmotionalResourceType = e.Emotional.ResourceType,
                                    EmotionalCity = e.Emotional.City,
                                    EmotionalState = e.Emotional.State,
                                    EmotionalInPerson = e.Emotional.InPerson,
                                    EmotionalUrl = e.Emotional.Url,
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<FavoritesListItem> GetFavoritesByPhysical()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Favorites
                        .Where(e => e.OwnerId == _userId && e.PhysicalId != null)
                        .Select(
                            e =>
                                new FavoritesListItem
                                {
                                    FavoriteId = e.FavoriteId,
                                    PhysicalId = e.PhysicalId,
                                    PhysicalCategoryType = e.Physical.CategoryType,
                                    PhysicalTitle = e.Physical.Title,
                                    PhysicalResourceType = e.Physical.ResourceType,
                                    PhysicalCity = e.Physical.City,
                                    PhysicalState = e.Physical.State,
                                    PhysicalInPerson = e.Physical.InPerson,
                                    PhysicalUrl = e.Physical.Url,
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<FavoritesListItem> GetFavoritesBySocial()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Favorites
                        .Where(e => e.OwnerId == _userId && e.SocialId != null)
                        .Select(
                            e =>
                                new FavoritesListItem
                                {
                                    FavoriteId = e.FavoriteId,
                                    SocialId = e.SocialId,
                                    SocialCategoryType = e.Social.CategoryType,
                                    SocialTitle = e.Social.Title,
                                    SocialResourceType = e.Social.ResourceType,
                                    SocialCity = e.Social.City,
                                    SocialState = e.Social.State,
                                    SocialInPerson = e.Social.InPerson,
                                    SocialUrl = e.Social.Url,
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<FavoritesListItem> GetFavoritesByFinancial()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Favorites
                        .Where(e => e.OwnerId == _userId && e.FinancialId != null)
                        .Select(
                            e =>
                                new FavoritesListItem
                                {
                                    FavoriteId = e.FavoriteId,
                                    FinancialId = e.FinancialId,
                                    FinancialCategoryType = e.Financial.CategoryType,
                                    FinancialTitle = e.Financial.Title,
                                    FinancialResourceType = e.Financial.ResourceType,
                                    FinancialCity = e.Financial.City,
                                    FinancialState = e.Financial.State,
                                    FinancialInPerson = e.Financial.InPerson,
                                    FinancialUrl = e.Financial.Url,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool RemoveFavoritesByEmotionalId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.EmotionalId == id);

                ctx.Favorites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveFavoritesByPhysicalId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.PhysicalId == id);

                ctx.Favorites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveFavoritesBySocialId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.SocialId == id);

                ctx.Favorites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveFavoritesByFinancialId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.OwnerId == _userId && e.FinancialId == id);

                ctx.Favorites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
