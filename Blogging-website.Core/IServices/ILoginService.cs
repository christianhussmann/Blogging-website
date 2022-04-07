using System.Collections.Generic;
using Bloggin_website.Core.Models;

namespace Bloggin_website.Core.IServices
{
    public interface ILoginService
    {
        Login UpdateLogin(Login login);
        Login DeleteLogin(int id);
        Login CreateLogin(Login login);
        List<Login> GetAllLogins();
        Login GetLoginById(int id);
        Login GetLoginByEmail(string email);

        bool CheckIfLoginExists(string email);

    }
}