using System;
using System.Linq;
using Blogging_website.Security.Entities;
using Blogging_website.Security.IRepositories;
using Blogging_website.Security.Models;

namespace Blogging_website.Security.Repositories
{
    public class AccountLoginRepository: IAccountLoginRepository
    {
        private readonly SecurityDbContext _ctx;

        public AccountLoginRepository(SecurityDbContext context)
        {
            _ctx = context;
        }
        
        public AccountLogin FindLogin(string email)
        {
            var entity = _ctx.AccountLogins
                .FirstOrDefault(customer => email.Equals(customer.Email));
            if (entity == null) return null;
            return new AccountLogin
            {
                Id = entity.Id,
                Email = entity.Email,
                HashedPassword = entity.HashedPassword,
                Salt = Convert.FromBase64String(entity.Salt),
                LoginId = entity.LoginId
            };
        }

        public AccountLogin CreateLogin(AccountLogin accountLogin)
        {
            var entity = _ctx.AccountLogins.Add(new AccountLoginEntity
            {
                Id = accountLogin.Id,
                Email = accountLogin.Email,
                HashedPassword = accountLogin.HashedPassword,
                Salt = Convert.ToBase64String(accountLogin.Salt),
                LoginId = accountLogin.LoginId
            }).Entity;

            _ctx.SaveChanges();

            return new AccountLogin
            {
                Id = entity.Id,
                Email = entity.Email,
                LoginId = entity.LoginId,
                HashedPassword = entity.HashedPassword,
                Salt = Convert.FromBase64String(entity.Salt)
            };
        }

        public void UpdateLoginId(int newId, string email)
        {
            var entity = _ctx.AccountLogins.FirstOrDefault(loginEntity => loginEntity.Email == email);

            if (entity != null)
            {
                _ctx.AccountLogins.Update(new AccountLoginEntity
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    Salt = entity.Salt,
                    HashedPassword = entity.HashedPassword,
                    LoginId = newId
                });
                _ctx.SaveChanges();
            }
        }

        public AccountLogin UpdateAccountLogin(AccountLogin accountLogin)
        {
            _ctx.ChangeTracker.Clear();
            var entity = _ctx.AccountLogins.Update(new AccountLoginEntity
            {
                Id = accountLogin.Id,
                Email = accountLogin.Email,
                Salt = Convert.ToBase64String(accountLogin.Salt),
                HashedPassword = accountLogin.HashedPassword,
                LoginId = accountLogin.LoginId
            }).Entity;
                
            _ctx.SaveChanges();

            return new AccountLogin
            {
                Id = entity.Id,
                Email = entity.Email,
                Salt = Convert.FromBase64String(entity.Salt),
                HashedPassword = entity.HashedPassword,
                LoginId = entity.LoginId
            };
        }
    }
}