using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class MoviesContext : DbContext
    {
        //Adds tables to the database
        public DbSet<Characters> Characters { get; set; }

        public DbSet<Franchise> Franchises { get; set; }

        public DbSet<Movie> Movies { get; set; }

        //Creates base options for the database
        public MoviesContext(DbContextOptions options) : base(options)
        {
        }

        //Seeding data on creation of the database, we have included some franchises without movies and some movies without characters 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Characters>()
                .HasData(new Characters
                {
                    Id = 1,
                    Name = "Martin Beck",
                    Gender = "Male",
                    Picture = "https://d2iltjk184xms5.cloudfront.net/uploads/photo/file/398271/large_96d68e3caff973a9e9a1695a287122b7-Martin-Beck.jpeg"
                });
            modelBuilder.Entity<Characters>()
                .HasData(new Characters
                {
                    Id = 2,
                    Name = "Gunvald Larsson",
                    Gender = "Male",
                    Picture = "https://d2iltjk184xms5.cloudfront.net/uploads/photo/file/181220/36667d2682a9ac81badb589957bad96a-gunvald.jpg"
                });
            modelBuilder.Entity<Characters>()
                .HasData(new Characters
                {
                    Id = 3,
                    Name = "Steinar Hovland",
                    Alias = "Tormund",
                    Gender = "Male",
                    Picture = "https://images.aftonbladet-cdn.se/v2/images/64545be9-e38e-4c01-be59-45e76c2b82d2?fit=crop&format=auto&h=994&q=50&w=1900&s=40dec49afa600cbe15caa261fb10f0584d00929e"
                });
            modelBuilder.Entity<Characters>()
                .HasData(new Characters
                {
                    Id = 4,
                    Name = "Ghostface",
                    Alias = "Father Death",
                    Gender = "Male",
                    Picture = "https://cdn.vox-cdn.com/thumbor/MfPfogfiF7COFcq4mrgyCct88n0=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/16305938/Ghost_Face.jpg"
                });
            modelBuilder.Entity<Franchise>()
              .HasData(new Franchise
              {
                  Id = 1,
                  Name = "Uncategorized",
                  Description = "No franchise, used for movies that are not part of a franchise",
              }); ;
            modelBuilder.Entity<Franchise>()
             .HasData(new Franchise
             {
                 Id = 2,
                 Name = "Scary Movie",
                 Description = "An American film series that comprises five parody films mainly focusing on spoofing horror films",
             }); ;
            modelBuilder.Entity<Franchise>()
              .HasData(new Franchise
              {
                  Id = 3,
                  Name = "The Fast and Furious",
                  Description = "A series of films, started off as racing movies and ended up as mad action movies",
              });
            modelBuilder.Entity<Franchise>().HasData(new Franchise
            {
                Id = 4,
                Name = "Beck",
                Description = "Swedish crime film series"
            });
            modelBuilder.Entity<Franchise>().HasData(new Franchise
            {
                Id = 5,
                Name = "Scream",
                Description = "American meta horror slasher"
            });
            modelBuilder.Entity<Movie>()
               .HasData(new Movie
               {
                   Id = 1,
                   MovieTitle = "Sista Vittnet",
                   Genre = "Thriller, Crime, Action",
                   Director = "Harald Hamrell",
                   ReleaseYear = 2002,
                   Trailer = "https://www.youtube.com/watch?v=2VS0a9B6ww4",
                   Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c1/Beck_16_-_Sista_vittnet.jpg/220px-Beck_16_-_Sista_vittnet.jpg",
                   FranchiseId = 4
               });
            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 2,
                    MovieTitle = "58 Minuter",
                    Genre = "Thriller, Crime, Action",
                    Director = "Lisa Ohlin",
                    ReleaseYear = 2022,
                    Trailer = "https://www.youtube.com/watch?v=gwZ0HZTHJSA",
                    Picture = "https://img-cdn.b17g.net/0348462b-d5b7-427c-b016-c3e93f3fbe30/crop2x3.jpg",
                    FranchiseId = 4
                });
            modelBuilder.Entity<Movie>()
               .HasData(new Movie
               {
                   Id = 3,
                   MovieTitle = "Scream",
                   Genre = "Horror",
                   Director = "Wes Craven",
                   ReleaseYear = 1996,
                   Trailer = "https://www.youtube.com/watch?v=AWm_mkbdpCA",
                   Picture = "https://img-cdn.b17g.net/0348462b-d5b7-427c-b016-c3e93f3fbe30/crop2x3.jpg",
                   FranchiseId = 5
               });
            modelBuilder.Entity<Movie>()
               .HasData(new Movie
               {
                   Id = 4,
                   MovieTitle = "Scre4m",
                   Genre = "Horror",
                   Director = "Wes Craven",
                   ReleaseYear = 2011,
                   Trailer = "https://www.youtube.com/watch?v=JKRtyVLWV-E",
                   Picture = "https://m.media-amazon.com/images/M/MV5BMjA2NjU5MTg5OF5BMl5BanBnXkFtZTgwOTkyMzQxMDE@._V1_.jpg",
                   FranchiseId = 5
               });
            modelBuilder.Entity<Movie>()
               .HasData(new Movie
               {
                   Id = 5,
                   MovieTitle = "Scary Movie",
                   Genre = "Parody, Comedy",
                   Director = "Keenen Ivory Wayans",
                   ReleaseYear = 2000,
                   Trailer = "https://www.youtube.com/watch?v=_dktIVAfjzY",
                   Picture = "https://m.media-amazon.com/images/M/MV5BMGEzZjdjMGQtZmYzZC00N2I4LThiY2QtNWY5ZmQ3M2ExZmM4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                   FranchiseId = 2
               });
            modelBuilder.Entity<Movie>()
                .HasMany(p => p.Characters)
                .WithMany(p => p.Movies)
                .UsingEntity(j => j.HasData(
                new { CharactersId = 1, MoviesId = 1 },
                new { CharactersId = 1, MoviesId = 2 },
                new { CharactersId = 2, MoviesId = 1 },
                new { CharactersId = 3, MoviesId = 2 },
                new { CharactersId = 4, MoviesId = 3 },
                new { CharactersId = 4, MoviesId = 4 },
                new { CharactersId = 4, MoviesId = 5 }
                ));
        }
    }
}
