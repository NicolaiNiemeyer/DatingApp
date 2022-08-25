using DatingApp.BL.Models;

namespace DatingApp.UI.Data
{
  public class AccountService
  {
    private AccountRepository _accountRepository;
    public List<Account> Accounts { get; set; } = new List<Account>();
    public AccountService(AccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }
    public List<Account> GetAccounts()
    {
      return _accountRepository.GetAllAccounts().ToList();
    }
  }
}
