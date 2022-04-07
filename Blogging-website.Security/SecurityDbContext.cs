using Blogging_website.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogging_website.Security
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }
        
        public DbSet<AccountLoginEntity> AccountLogins { get; set; }
    }
}