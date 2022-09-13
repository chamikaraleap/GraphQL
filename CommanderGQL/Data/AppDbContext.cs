

using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Platform>()
            .HasMany(f => f.Commands)
            .WithOne(p => p.Platform!)
            .HasForeignKey(f => f.PlatformId);

            modelBuilder
            .Entity<Command>()
            .HasOne(f => f.Platform)
            .WithMany(p => p.Commands)
            .HasForeignKey(f => f.PlatformId);
        }
    }
}