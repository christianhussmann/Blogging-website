using Blogging_website.Security.Models;

namespace Blogging_website.Security.IServices
{
    public interface IAccountLoginService
    {
        AccountLogin GetAccountLogin(string email);
        AccountLogin CreateLogin(AccountLogin accountLogin);
        void UpdateLoginId(int id, string email);
        AccountLogin UpdateAccountLogin(AccountLogin accountLogin);
    }
}