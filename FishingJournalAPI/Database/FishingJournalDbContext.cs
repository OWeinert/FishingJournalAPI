using FishingJournal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Database
{
    public class FishingJournalDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Users Table
        /// </summary>
        public DbSet<User> Users { get; set; }


        public FishingJournalDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SQLite"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique(true);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique(true);
        }
    }
}
