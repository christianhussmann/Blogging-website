using System.Collections.Generic;
using Bloggin_website.Core.Models;

namespace Blogging_website.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Login GetLoginById(int id);
        
        Login GetLoginByEmail(string email);

        List<Login> GetAllLogins();
        bool CheckIfLoginExists(string email);

        Login CreateLogin(Login login);

        Login DeleteLogin(int id);

        Login UpdateLogin(Login login);
    }
}