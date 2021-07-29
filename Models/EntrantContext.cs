using Microsoft.EntityFrameworkCore;

namespace EntrantsApi.Models
{
    // This class manages the Entity Framework functionality for the Entrant data model
    public class EntrantContext : DbContext
    {
        public EntrantContext(DbContextOptions<EntrantContext> options)
            : base(options)
        {
        }

        public DbSet<Entrant> Entrant { get; set; }
    }
}