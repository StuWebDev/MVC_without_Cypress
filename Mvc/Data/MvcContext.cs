namespace Mvc.Data
{
    public class MvcContext : DbContext
    {
        public MvcContext (DbContextOptions<MvcContext> options)
            : base(options)
        {
        }

        public DbSet<Mvc.Models.Movie> Movie { get; set; }
    }
}
