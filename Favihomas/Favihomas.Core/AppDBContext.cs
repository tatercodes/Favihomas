using Microsoft.EntityFrameworkCore;

namespace Favihomas.Core
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { 
        
        }

        public DbSet<AuditAction> AuditActions { get; set; } 
    }
}
