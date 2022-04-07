using Blogging_website.Security.Entities;

namespace Blogging_website.Security
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }
        
        public DbSet<AccountLoginEntity> AccountLogin { get; set; }
    }
}