using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Data
{
    public static class SeedDb
    {
        public static void Execute(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            ApplicationDbContext applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            applicationDbContext.Villas.Add(new Villa()
            {
                Id = 1,
                Name = "Royal Villa",
                Details = "Some detail of Royal Villa",
                ImageUrl = "",
                Occupancy = 5,
                Rate = 200,
                Sqft = 550,
                Amenity = "",
                DateCreated = DateTime.Now
            });

            applicationDbContext.Villas.Add(new Villa()
            {
                Id = 2,
                Name = "Royal Villa",
                Details = "Some detail of Royal Villa",
                ImageUrl = "",
                Occupancy = 5,
                Rate = 200,
                Sqft = 550,
                Amenity = "",
                DateCreated = DateTime.Now
            });

            applicationDbContext.Villas.Add(new Villa()
            {
                Id = 3,
                Name = "Luxury Pool Villa",
                Details = "Some detail of Luxury Pool Villa",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 400,
                Sqft = 550,
                Amenity = "",
                DateCreated = DateTime.Now
            });

            applicationDbContext.Villas.Add(new Villa()
            {
                Id = 4,
                Name = "Diamond Villa",
                Details = "Some detail of Diamond Villa",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 400,
                Sqft = 550,
                Amenity = "",
                DateCreated = DateTime.Now
            });

            applicationDbContext.Villas.Add(new Villa()
            {
                Id = 5,
                Name = "Diamond Pool Villa",
                Details = "Some detail of Diamond Villa",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 400,
                Sqft = 550,
                Amenity = "",
                DateCreated = DateTime.Now
            });


            applicationDbContext.VillaNumbers.Add(new VillaNumber()
            {
                VillaNo = 101,
                VillaId = 1,
                SpecialDetails = "This is the special one!",
                CreatedDate = DateTime.Now,
            });

            applicationDbContext.VillaNumbers.Add(new VillaNumber()
            {
                VillaNo = 102,
                VillaId = 1,
                SpecialDetails = "This has sea view!",
                CreatedDate = DateTime.Now,
            });

            applicationDbContext.VillaNumbers.Add(new VillaNumber()
            {
                VillaNo = 103,
                VillaId = 1,
                SpecialDetails = "This is the smallest one!",
                CreatedDate = DateTime.Now,
            });

            applicationDbContext.SaveChanges();
        }
    }
}
