using DatingApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BL.Services
{
  public interface IAccountService : IDataService<Account>
  {
    Task<Account> GetByUsername(string username);
  }
}
