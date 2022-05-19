using Microsoft.EntityFrameworkCore;
using Onion.AppCore.Entities;

namespace Onion.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Storekeeper> Storekeepers { get; set; }
        public DbSet<Detail> Details { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
            Database.Migrate();
        }

    }
}
