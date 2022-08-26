using DatingApp.BL.Models;
using DatingApp.EntityFramework;

namespace DatingApp.UI.Data
{
  public class AccountService
  {
    private readonly ApplicationDbContext _context;
    public List<Account> Accounts { get; set; } = new List<Account>();
    public AccountService(ApplicationDbContext context)
    {
      _context = context;
    }
    public List<String> GetAccounts()
    {
      return _context.Accounts
        .Select(c => c.UserName)
        .ToList();
    }
  }
}
