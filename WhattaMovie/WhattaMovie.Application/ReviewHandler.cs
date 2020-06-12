using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhattaMovie.Domain;

namespace WhattaMovie.Application
{
    public class ReviewHandler : IEntityCrudHandler<Review>
    {
        private readonly IApplicationDbContext db;
        public ReviewHandler(IApplicationDbContext db) => this.db = db;
        public async Task<int> Alterar(int id, Review review, int userID)
        {
            var toAlter = await db.Reviews.SingleOrDefaultAsync(r=>r.ID==id);
            if (toAlter !=null && toAlter.OwnerID == userID)
            {
                toAlter.Title = review.Title??toAlter.Title;
                toAlter.Comment = review.Comment??toAlter.Comment;
                toAlter.LastModifiedOn = DateTime.Now;
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(Review review)
        {
            review.CreatedOn = DateTime.Now;
            review.LastModifiedOn = DateTime.Now;
            db.Reviews.Add(review);
            return await db.SaveChangesAsync();
        }

        public async Task<Review[]> Listar(int userID)
        {
            return await db.Reviews.Where(r=>r.OwnerID==userID).ToArrayAsync();
        }

        public async Task<Review> ObterUm(int id, int userID)
        {
            return await db.Reviews.Where(r => r.OwnerID == userID).SingleOrDefaultAsync(r => r.ID == id);
        }

        public async Task<int> Remover(int id, int userID)
        {
            var toRemove=await db.Reviews.SingleOrDefaultAsync(r=>r.ID==id);
            if (toRemove!= null && toRemove.OwnerID==userID)
            {
                db.Reviews.Remove(toRemove);
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }
    }
}
