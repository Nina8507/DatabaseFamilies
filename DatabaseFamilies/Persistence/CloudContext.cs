using DatabaseFamilies.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFamilies.Persistence
{
    public class CloudContext:DbContext
    {
        public DbSet<User> UserTable { get; set; }
        public DbSet<Family> FamilyTable { get; set; }
        public DbSet<Adult> AdultTable { get; set; }
        public DbSet<Child> ChildTable { get; set; }
        public DbSet<Pet> PetTable { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\const\RiderProjects\DatabaseFamilies\DatabaseFamilies\SQLiteFam");
        }
    }
}