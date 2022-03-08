using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class HvZContext : DbContext
    {
        //Adds tables to the database
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }


        //Creates base options for the database
        public HvZContext(DbContextOptions options) : base(options)
        {
        }

        //Seeding data on creation of the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    first_Name = "Martin",
                    last_Name = "Späck",
                });


            modelBuilder.Entity<Game>()
              .HasData(new Game
              {
                  Id = 1,
                  Name = "Norrköpings zombie spel",
                  Game_state = 1,
              });

           
            //modelBuilder.Entity<Movie>()
            //    .HasMany(p => p.Characters)
            //    .WithMany(p => p.Movies)
            //    .UsingEntity(j => j.HasData(
            //    new { CharactersId = 1, MoviesId = 1 },
            //    new { CharactersId = 1, MoviesId = 2 },
            //    new { CharactersId = 2, MoviesId = 1 },
            //    new { CharactersId = 3, MoviesId = 2 },
            //    new { CharactersId = 4, MoviesId = 3 },
            //    new { CharactersId = 4, MoviesId = 4 },
            //    new { CharactersId = 4, MoviesId = 5 }
            //    ));
        }
    }
}
