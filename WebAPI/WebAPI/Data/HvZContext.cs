using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Domain;

namespace WebAPI.Data
{
    public class HvZContext : DbContext
    {
        //Adds tables to the database
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Kill> Kills { get; set; }

        public DbSet<Squad> Squads { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Mission> Missions { get; set; }

        public DbSet<Squadmember> SquadMembers { get; set; }

        public DbSet<SquadCheckIn> SquadCheckIns { get; set; }

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
                    Is_Human = true,
                    Is_Patient_Zero = false,
                    Bite_Code = "JagBetDig434"

                });
            modelBuilder.Entity<Player>()
        .HasData(new Player
        {
            Id = 2,
            UserId = 2,
            GameId = 1,
            Is_Human = false,
            Is_Patient_Zero = true,
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

            modelBuilder.Entity<Squad>()
                .HasData(new Squad
                {
                    Id = 1,
                    GameID = 1,
                    Name = "Mega-squad",
                    IsHuman = true,
                });


            modelBuilder.Entity<Chat>()
              .HasOne(k => k.Player)
              .WithMany(k => k.PlayerChats)
              .HasForeignKey(k => k.PlayerId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Chat>()
             .HasOne(k => k.Squad)
             .WithMany(k => k.SquadChats)
             .HasForeignKey(k => k.SquadId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Chat>()
             .HasOne(k => k.Game)
             .WithMany(k => k.GameChats)
             .HasForeignKey(k => k.GameId)
             .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Chat>()
              .HasData(new Chat
              {
                  Id = 1,
                  GameId = 1,
                  PlayerId = 2,
                  SquadId = 1,
                  Message = "Im the best, u scrubz",
                  Is_Human_Global = true,
                  Is_Zombie_Global = false,
                  Chat_Time = "13:04"
              });

            modelBuilder.Entity<Mission>()
              .HasData(new Mission
              {
                  Id = 1,
                  GameId = 1,
                  Name = "Secret Coop mission",
                  Is_Human_Visible = false,
                  Is_Zombie_Visible = true,
                  Description = "Shop energy drinks at coop",
              });

            modelBuilder.Entity<Squadmember>()
            .HasData(new Squadmember
            {
                Id = 1,
                GameId = 1,
                PlayerId = 2,
                SquadId = 1,
                Rank = "Generals"
            });

            modelBuilder.Entity<Squadmember>()
       .HasOne(k => k.Player)
       .WithMany(k => k.Squadmembers)
       .HasForeignKey(k => k.PlayerId)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Squadmember>()
             .HasOne(k => k.Squad)
             .WithMany(k => k.Squadmembers)
             .HasForeignKey(k => k.SquadId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Squadmember>()
             .HasOne(k => k.Game)
             .WithMany(k => k.Squadmembers)
             .HasForeignKey(k => k.GameId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SquadCheckIn>()
         .HasData(new SquadCheckIn
         {
             Id = 1,
             GameId = 1,
             SquadId = 1,
             SquadmemberId = 1,
             Start_Time = "13:37",
             End_Time = "14:20",
             Lat = 41.2313,
             Lng = 2.21312
         });

            modelBuilder.Entity<SquadCheckIn>()
        .HasOne(k => k.Squadmember)
        .WithMany(k => k.SquadCheckIns)
        .HasForeignKey(k => k.SquadmemberId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SquadCheckIn>()
             .HasOne(k => k.Squad)
             .WithMany(k => k.SquadCheckIns)
             .HasForeignKey(k => k.SquadId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SquadCheckIn>()
             .HasOne(k => k.Game)
             .WithMany(k => k.SquadCheckIns)
             .HasForeignKey(k => k.GameId)
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
