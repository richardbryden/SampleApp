using FundAdministration.Models;
using Microsoft.EntityFrameworkCore;

namespace FundAdministration.Db
{
    public class FundAdministrationContext : DbContext
    {
        public FundAdministrationContext(DbContextOptions<FundAdministrationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            // Seed the database with some data
            new DataSeeder(this).SeedData().Wait();
        }

        public DbSet<Fund> Funds { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}