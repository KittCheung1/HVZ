using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class HvZContext : DbContext
    {
        //Adds tables to the database
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Kill> Kills { get; set; }


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
                    First_Name = "Martin",
                    Last_Name = "Späck",
                });
            modelBuilder.Entity<User>()
             .HasData(new User
             {
                 Id = 2,
                 First_Name = "Gunvald",
                 Last_Name = "Larsson",
             });


            modelBuilder.Entity<Game>()
              .HasData(new Game
              {
                  Id = 1,
                  Name = "Norrköpings zombie spel",
                  Game_state = 1,
              });

            modelBuilder.Entity<Player>()
                .HasData(new Player
                {
                    Id = 1,
                    UserId = 1,
                    GameId = 1,
                    Is_Human = 1,
                    Is_Patient_Zero = 0,
                    Bite_Code = "JagBetDig434"

                });
            modelBuilder.Entity<Player>()
        .HasData(new Player
        {
            Id = 2,
            UserId = 2,
            GameId = 1,
            Is_Human = 0,
            Is_Patient_Zero = 1,
            Bite_Code = "JagBetDig123"

        });

            modelBuilder.Entity<Kill>()
            .HasData(new Kill
            {
                Id = 1,
                KillerId = 1,
                VictimId = 2,
                GameId = 1,
                Time_Of_Death = "10:33"
            });



            modelBuilder.Entity<Kill>()
                .HasOne(k => k.Killer)
                .WithMany(k => k.Kills)
                .HasForeignKey(k => k.KillerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Kill>()
               .HasOne(k => k.Victim)
               .WithMany(k => k.Deaths)
               .HasForeignKey(k => k.VictimId)
               .OnDelete(DeleteBehavior.NoAction);




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
