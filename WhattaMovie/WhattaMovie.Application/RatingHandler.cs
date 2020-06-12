using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhattaMovie.Domain;

namespace WhattaMovie.Application
{
    public class RatingHandler : IEntityCrudHandler<Rating>
    {
        private readonly IApplicationDbContext db;
        public RatingHandler(IApplicationDbContext db) => this.db = db;

        public async Task<int> Alterar(int id, Rating rating, int userID)
        {
            var toAlter = await db.Ratings.SingleOrDefaultAsync(r=>r.ID==id);
            if (toAlter != null && toAlter.OwnerID == userID)
            {
                toAlter.MovieRating = rating.MovieRating;
                toAlter.LastModifiedOn = DateTime.Now;
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(Rating rating)
        {
            rating.CreatedOn = DateTime.Now;
            rating.LastModifiedOn=DateTime.Now;
            db.Ratings.Add(rating);
            return await db.SaveChangesAsync();
        }

        public async Task<Rating[]> Listar(int userID)
        {
            return await db.Ratings.Where(r=>r.OwnerID==userID).ToArrayAsync();
        }

        public async Task<Rating> ObterUm(int id, int userID)
        {
            return await db.Ratings.Where(r => r.OwnerID == userID).SingleOrDefaultAsync(r=>r.ID==id);
        }

        public async Task<int> Remover(int id, int userID)
        {
            var toRemove=await db.Ratings.SingleOrDefaultAsync(r=>r.ID==id);
            if (toRemove != null && toRemove.OwnerID==userID)
            {
                db.Ratings.Remove(toRemove);
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }
    }
}
