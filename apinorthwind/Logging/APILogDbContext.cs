using Microsoft.EntityFrameworkCore;

namespace apinorthwind.Logging
{
    public class APILogDbContext : DbContext
    {
        public APILogDbContext(DbContextOptions<APILogDbContext> options) : base(options) { }

        public DbSet<APILog> APILogs { get; set; }
    }
}
