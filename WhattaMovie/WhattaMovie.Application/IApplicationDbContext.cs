using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhattaMovie.Domain;

namespace WhattaMovie.Application
{
    public interface IApplicationDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
