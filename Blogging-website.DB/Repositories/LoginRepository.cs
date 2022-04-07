using System.Collections.Generic;
using Bloggin_website.Core.Models;
using Blogging_website.Domain.IRepositories;

namespace Blogging_website.DB.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly BloggingWebsiteDbContext _ctx;
        
        
        
        public Login GetLoginById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Login GetLoginByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<Login> GetAllLogins()
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfLoginExists(string email)
        {
            throw new System.NotImplementedException();
        }

        public Login CreateLogin(Login login)
        {
            throw new System.NotImplementedException();
        }

        public Login DeleteLogin(int id)
        {
            throw new System.NotImplementedException();
        }

        public Login UpdateLogin(Login login)
        {
            throw new System.NotImplementedException();
        }
    }
}