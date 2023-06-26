﻿using FishingJournal.API.Models;
using FishingJournal.API.Models.JournalEntry;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Database
{
    /// <summary>
    /// EFCore DbContext of the FishingJournal database
    /// </summary>
    public class FishingJournalDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Users table
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Journal Entries table
        /// </summary>
        public DbSet<JournalEntry> JournalEntries { get; set; }

        /// <summary>
        /// Fish Types table
        /// </summary>
        public DbSet<FishType> FishTypes { get; set; }

        /// <summary>
        /// Rig Types table
        /// </summary>
        public DbSet<RigType> RigTypes { get; set; }

        /// <summary>
        /// Hook Types table
        /// </summary>
        public DbSet<HookType> HookTypes { get; set; }

        /// <summary>
        /// Weather Types table
        /// </summary>
        public DbSet<WeatherType> WeatherTypes { get; set; }

        /// <summary>
        /// Water Surface Types table
        /// </summary>
        public DbSet<WaterSurfaceType> WaterSurfaceTypes { get; set; }

        /// <summary>
        /// Water Current Types table
        /// </summary>
        public DbSet<WaterCurrentType> WaterCurrentTypes { get; set; }


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
