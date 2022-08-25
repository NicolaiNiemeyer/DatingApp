using DatingApp.BL.Models;
using DatingApp.EntityFramework;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace DatingApp.UI.Data
{
  public class AccountRepository
  {
    private readonly ApplicationDbContext _context;
    public List<Account> Accounts { get; set; }
    public AccountRepository()
    {
      Accounts = new List<Account>();
      var accounts = _context.Accounts
        .Select(t => t.UserName)
        .ToList();
    }

    public List<Account> GetAllAccounts()
    {
      return Accounts;
    }
  }
}
