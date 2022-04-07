using Blogging_website.Security.Models;

namespace Blogging_website.Security.IRepositories
{
    public interface IAccountLoginRepository
    {
        AccountLogin FindLogin(string email);

        AccountLogin CreateLogin(AccountLogin accountLogin);

        void UpdateLoginId(int newId, string email);

        AccountLogin UpdateAccountLogin(AccountLogin accountLogin);
    }
}