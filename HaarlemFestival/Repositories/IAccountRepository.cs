using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaarlemFestival.Repositories
{
    interface IAccountRepository
    {
        Account GetAccount(string Email, string password);
        Account GetAccount(string Email);
        Account GetAccount(int Id);
        void Register(Account account);
    }
}
