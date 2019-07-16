using CleanWebApi.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApi.Persistence
{
    public class CleanWebApiDbContext : DbContext, ICleanWebApiDbContext
    {
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