namespace Blogging_website.Security
{
    public interface ISecurityDbContextSeeder
    {
        void SeedDevelopment();

        void SeedProduction();
    }
}