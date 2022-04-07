using System.Collections.Generic;
using System.IO;
using Bloggin_website.Core.IServices;
using Bloggin_website.Core.Models;
using Blogging_website.Domain.IRepositories;

namespace Blogging_website.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            if (loginRepository == null)
            {
                throw new InvalidDataException("Login repository cannot be null");
            }
            else
            {
                _loginRepository = loginRepository;
            }
        }
        
        public Login UpdateLogin(Login login)
        {
            return _loginRepository.UpdateLogin(login);
        }

        public Login DeleteLogin(int id)
        {
            return _loginRepository.DeleteLogin(id);
        }

        public Login CreateLogin(Login login)
        {
            return _loginRepository.CreateLogin(login);
        }

        public List<Login> GetAllLogins()
        {
            return _loginRepository.GetAllLogins();
        }

        public Login GetLoginById(int id)
        {
            return _loginRepository.GetLoginById(id);
        }

        public Login GetLoginByEmail(string email)
        {
            return _loginRepository.GetLoginByEmail(email);
        }

        public bool CheckIfLoginExists(string email)
        {
            return _loginRepository.CheckIfLoginExists(email);
        }
    }
}