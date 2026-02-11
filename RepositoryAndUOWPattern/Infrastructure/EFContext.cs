using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    internal class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options): base(options)
        {
            
        }
        public DbSet<Authors> Authors { get; set; }
    }
}
