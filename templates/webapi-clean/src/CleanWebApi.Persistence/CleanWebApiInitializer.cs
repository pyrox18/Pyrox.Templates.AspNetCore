namespace CleanWebApi.Persistence
{
    public class CleanWebApiInitializer
    {
        private readonly CleanWebApiDbContext _context;

        public CleanWebApiInitializer(CleanWebApiDbContext context) =>
            _context = context;

        public void SeedAllData()
        {
        }

        public static void Initialize(CleanWebApiDbContext context)
        {
            var initializer = new CleanWebApiInitializer(context);
            initializer.SeedAllData();
        }
    }
}