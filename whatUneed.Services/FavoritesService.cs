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
                                    EmotionalId = e.EmotionalId,
                                    PhysicalId = e.PhysicalId,
                                    SocialId = e.SocialId,
                                    FinancialId = e.FinancialId,

                                }
                        );

                return query.ToArray();
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
                                    PhysicalId = e.PhysicalId,
                                    SocialId = e.SocialId,
                                    FinancialId = e.FinancialId,

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
                                    EmotionalId = e.EmotionalId,
                                    PhysicalId = e.PhysicalId,
                                    SocialId = e.SocialId,
                                    FinancialId = e.FinancialId,

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
                                    EmotionalId = e.EmotionalId,
                                    PhysicalId = e.PhysicalId,
                                    SocialId = e.SocialId,
                                    FinancialId = e.FinancialId,

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
                                    EmotionalId = e.EmotionalId,
                                    PhysicalId = e.PhysicalId,
                                    SocialId = e.SocialId,
                                    FinancialId = e.FinancialId,

                                }
                        );

                return query.ToArray();
            }
        }
    }
}
