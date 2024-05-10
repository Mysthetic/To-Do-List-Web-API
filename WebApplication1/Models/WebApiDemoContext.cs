using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;

namespace WebApplication1.Models
{
    public class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext(DbContextOptions<WebApiDemoContext> option) : base(option) 
        {
        }

       
        public DbSet<TodoEntry> TodoEntries { get; set; } = null!;
        //public DbSet<TodoTag> Tags { get; set; } = null!;
        //public DbSet<Users> Users { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TodoEntry>()
        //        .HasMany(e => e.Tags)
        //        .WithMany(e => e.TaggedEntries);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Users)
        //        .WithMany(e => e.TaggedEntries);
        //}
    }
}
