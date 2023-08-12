using System;
using Microsoft.EntityFrameworkCore;
using DeveloperTest.Database.Models;

namespace DeveloperTest.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Engineer> Engineers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasKey(x => x.JobId);
            modelBuilder.Entity<Job>()
                .HasOne(e => e.Engineer)
                .WithMany(e => e.Jobs);
            modelBuilder.Entity<Job>()
                .Property(x => x.JobId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Engineer>()
                .HasKey(e => e.EngineerId);
            modelBuilder.Entity<Engineer>()
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}
