using Blogging_website.Security.Models;

namespace Blogging_website.Security.IServices
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string email, string password);
        
        bool Authenticate(string plainPassword, AccountLogin login);
        
        string HashPassword(string plainPassword, byte[] salt);
        
        byte[] GenerateSalt();
    }
}