using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
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
                },
                new Villa()
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
                },
                new Villa()
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
                },
                new Villa()
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
                },
                new Villa()
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
                }
                );
        }
    }
}
