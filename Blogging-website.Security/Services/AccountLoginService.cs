using Blogging_website.Security.IRepositories;
using Blogging_website.Security.IServices;
using Blogging_website.Security.Models;

namespace Blogging_website.Security.Services
{
    public class AccountLoginService : IAccountLoginService
    {
        private readonly IAccountLoginRepository _loginRepository;

        public AccountLoginService(IAccountLoginRepository accountLoginRepository)
        {
            _loginRepository = accountLoginRepository;
        }
        
        public AccountLogin GetAccountLogin(string email)
        {
            return _loginRepository.FindLogin(email);
        }

        public AccountLogin CreateLogin(AccountLogin accountLogin)
        {
            return _loginRepository.CreateLogin(accountLogin);
        }

        public void UpdateLoginId(int newId, string email)
        {
            _loginRepository.UpdateLoginId(newId, email);
        }

        public AccountLogin UpdateAccountLogin(AccountLogin accountLogin)
        {
            return _loginRepository.UpdateAccountLogin(accountLogin);
        }
    }
}