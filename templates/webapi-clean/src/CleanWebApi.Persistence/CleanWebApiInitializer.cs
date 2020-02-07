using CleanWebApi.Domain.Entities;
using System;

namespace CleanWebApi.Persistence
{
    public class CleanWebApiInitializer
    {
        private readonly CleanWebApiDbContext _context;

        public CleanWebApiInitializer(CleanWebApiDbContext context) =>
            _context = context;

        public void SeedAllData()
        {
            var message = new Message("Sample message", DateTimeOffset.Now);

            _context.Messages.Add(message);

            _context.SaveChangesAsync();
        }

        public static void Initialize(CleanWebApiDbContext context)
        {
            var initializer = new CleanWebApiInitializer(context);
            initializer.SeedAllData();
        }
    }
}