using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirtRivalsswag.Models;
using Models;

namespace DirtRivalsswag
{
    public class DailyChallengeContext : DbContext
    {
        public DailyChallengeContext(DbContextOptions<DailyChallengeContext> options)
                : base(options)
        { }

        public DbSet<MetaData> Metadatas { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Rival> Rivals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Entry>()
                .HasKey(c => c.ChallengeId);
            modelBuilder.Entity<Entry>()
                .HasKey(e => e.Id);
             //"DirtPlayer" driverName not unique..
            modelBuilder.Entity<MetaData>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Rival>().HasKey(r => r.Id);
            modelBuilder.Entity<Rival>().HasIndex(r => r.DriverName).IsUnique();




            // modelBuilder.Entity<Entry>().HasOne(c => c.Challenge_Id ).WithMany(c => c.entries);
            //.HasForeignKey("EntryReferenceName") c.Id?
            // .HasForeignKey("").IsRequired()
        }

    }
}

