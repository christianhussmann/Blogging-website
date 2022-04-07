namespace Blogging_website.DB
{
    public class BloggingWebsiteDbContextSeeder: IBloggingWebsiteDbContextSeeder

    {
    private readonly BloggingWebsiteDbContext _ctx;

    public BloggingWebsiteDbContextSeeder(BloggingWebsiteDbContext context)
    {
        _ctx = context;
    }
    
    
    
    public void SeedDevelopment()
    {
        _ctx.Database.EnsureDeleted();
        _ctx.Database.EnsureCreated();
    }

    public void SeedProduction()
    {
        throw new System.NotImplementedException();
    }
    }
}