using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival.Model;

namespace HaarlemFestival.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private DBHF db;

        public AccountRepository(DBHF db)
        {
            this.db = db;
        }

        public Account GetAccount(string Email, string password)
        {
            return db.Accounts.SingleOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(password));
        }

        public Account GetAccount(int Id)
        {
            return db.Accounts.SingleOrDefault(a => a.Id.Equals(Id));
        }

        public Account GetAccount(string Email)
        {
            return db.Accounts.SingleOrDefault(a => a.Email.Equals(Email));
        }

        public void Register(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
        }
    }
}