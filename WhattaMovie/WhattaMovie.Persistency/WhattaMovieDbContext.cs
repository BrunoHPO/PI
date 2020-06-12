using Microsoft.EntityFrameworkCore;
using System;
using WhattaMovie.Application;
using WhattaMovie.Domain;

namespace WhattaMovie.Persistency
{
    public class WhattaMovieDbContext : DbContext, IApplicationDbContext
    {
        public WhattaMovieDbContext(DbContextOptions<WhattaMovieDbContext> options) : base(options)
        { 
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(m => m.ID);
            modelBuilder.Entity<Movie>().Property(m => m.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Review>().HasKey(r => r.ID);
            modelBuilder.Entity<Review>().Property(r => r.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Rating>().HasKey(r => r.ID);
            modelBuilder.Entity<Rating>().Property(r => r.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasKey(u => u.ID);
            modelBuilder.Entity<User>().Property(u => u.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Owner)
                .WithMany(o => o.Movies)
                .HasForeignKey(m => m.OwnerID);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(m => m.MovieID);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Ratings)
                .WithOne(r => r.Movie)
                .HasForeignKey(m => m.MovieID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.Reviews)
                .HasForeignKey(r => r.OwnerID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(o => o.Reviews)
                .HasForeignKey(r => r.MovieID);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.Ratings)
                .HasForeignKey(r => r.OwnerID);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movie)
                .WithMany(o => o.Ratings)
                .HasForeignKey(r => r.MovieID);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Movies)
                .WithOne(m => m.Owner)
                .HasForeignKey(u => u.OwnerID);

            modelBuilder.Entity<User>()
               .HasMany(u => u.Ratings)
               .WithOne(m => m.Owner)
               .HasForeignKey(u => u.OwnerID);

            modelBuilder.Entity<User>()
               .HasMany(u => u.Reviews)
               .WithOne(m => m.Owner)
               .HasForeignKey(u => u.OwnerID);

            modelBuilder.Entity<User>().HasData(new User[] {
                new User(){ ID = 1, Username = "Admin1", Role = "admin", ApiKey = Guid.NewGuid().ToString(), ApiSecret = Guid.NewGuid().ToString()},
                new User(){ ID = 2, Username = "Admin2", Role = "admin", ApiKey = Guid.NewGuid().ToString(), ApiSecret = Guid.NewGuid().ToString()},
                new User(){ ID = 3, Username = "User1", Role = "user", ApiKey = Guid.NewGuid().ToString(), ApiSecret = Guid.NewGuid().ToString()},
                new User(){ ID = 4, Username = "User2", Role = "user", ApiKey = Guid.NewGuid().ToString(), ApiSecret = Guid.NewGuid().ToString()}
            });
        }
    }
}
