using Blogging_website.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogging_website.DB
{
    public class BloggingWebsiteDbContext : DbContext
    {
        public DbSet<LoginEntity> Logins { get; set; }
    }
}