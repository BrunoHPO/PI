using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhattaMovie.Domain;

namespace WhattaMovie.Application
{
    public class MovieHandler : IEntityCrudHandler<Movie>
    {
        private readonly IApplicationDbContext db;
        public MovieHandler(IApplicationDbContext db) => this.db = db;

        public async Task<int> Alterar(int id, Movie movie, int userID)
        {
            var toAlter= await db.Movies.SingleOrDefaultAsync(m=>m.ID==id);
            var user = await db.Users.SingleOrDefaultAsync(u => u.ID == userID);
            if (toAlter != null && user.Role=="admin")
            {
                toAlter.Tittle = movie.Tittle ?? toAlter.Tittle;
                toAlter.Description = movie.Description ?? toAlter.Description;
                toAlter.Year = movie.Year;
                toAlter.Genre = movie.Genre ?? toAlter.Genre;
                movie.LastModifiedOn = DateTime.Now;
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(Movie movie)
        {
            movie.CreatedOn = DateTime.Now;
            movie.LastModifiedOn = DateTime.Now;
            db.Movies.Add(movie);
            return await db.SaveChangesAsync();
        }

        public async Task<Movie[]> Listar(int userID)
        {
            return await db.Movies.ToArrayAsync();
        }

        public async Task<Movie> ObterUm(int id, int userID)
        {
            return await db.Movies.SingleOrDefaultAsync(m=>m.ID==id);
        }

        public async Task<int> Remover(int id, int userID)
        {
            var toRemove = await db.Movies.SingleOrDefaultAsync(m => m.ID == id);
            var user = await db.Users.SingleOrDefaultAsync(u => u.ID == userID);
            if (toRemove!= null && user.Role == "admin")
            {
                db.Movies.Remove(toRemove);
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }
    }
}
