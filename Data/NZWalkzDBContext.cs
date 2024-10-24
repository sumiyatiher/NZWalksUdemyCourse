using Microsoft.EntityFrameworkCore;
using NZWalkz.API.Models.DomainModels;

namespace NZWalkz.API.Data
{
    public class NZWalkzDBContext: DbContext
    {
        //Shorcut to create this below => ctor and tab
        public NZWalkzDBContext(DbContextOptions<NZWalkzDBContext> dbContextOption) : base(dbContextOption)
        {
            
        }
        //Shorcut to create this above => ctor and tab


        //DBSETS : PROPERTY OF DBContext class that refresence entity in database
        //In this case we have 3 entities, they are Walks,Difficulty,Region
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy,Medium,Hard
            var Difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    DifficultyId = Guid.Parse("e89b600a-4896-49ef-9dcd-9a091b27d28f"),
                    Name = "Easy"
                },
                 new Difficulty()
                {
                    DifficultyId = Guid.Parse("c777a7cf-8028-456e-98d9-562cd8ed2bb7"),
                    Name = "Medium"
                },
                  new Difficulty()
                {
                    DifficultyId = Guid.Parse("f0222f83-eb65-408c-b8a6-809d017b8c29"),
                    Name = "Hard"
                }

            };

            //Seed Difficulties to database
            modelBuilder.Entity<Difficulty>().HasData(Difficulties);

            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    RegionId = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageURL = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    RegionId = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageURL = null
                },
                new Region
                {
                    RegionId = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageURL = null
                },
                new Region
                {
                    RegionId = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    RegionId = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageURL = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    RegionId = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageURL = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
