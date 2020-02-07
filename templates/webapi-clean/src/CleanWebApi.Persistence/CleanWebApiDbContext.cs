using CleanWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApi.Persistence
{
    public class CleanWebApiDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public CleanWebApiDbContext(DbContextOptions<CleanWebApiDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanWebApiDbContext).Assembly);
        }
    }
}