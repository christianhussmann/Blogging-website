namespace Blogging_website.DB
{
    public interface IBloggingWebsiteDbContextSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}