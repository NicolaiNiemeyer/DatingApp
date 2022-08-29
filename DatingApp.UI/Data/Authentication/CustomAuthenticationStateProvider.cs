using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace DatingApp.UI.Data.Authentication
{
  public class CustomAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly ProtectedSessionStorage _protectedSessionStorage;
    private ClaimsPrincipal _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage)
    {
      _protectedSessionStorage = protectedSessionStorage;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      try
      {
        var userSessionStorageResult = await _protectedSessionStorage.GetAsync<UserSession>("UserSession");
        var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
        if (userSession == null)
          return await Task.FromResult(new AuthenticationState(_claimsPrincipal));
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.UserName),
                new Claim(ClaimTypes.Role, userSession.Role)
            }, "CustomAuth"));
        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
      }
      catch
      {
        return await Task.FromResult(new AuthenticationState(_claimsPrincipal));
      }
    }

    public async Task UpdateAuthenticationState(UserSession userSession)
    {
      ClaimsPrincipal claimsPrincipal;

      if (userSession != null)
      {
        await _protectedSessionStorage.SetAsync("UserSession", userSession);
        claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
      }
      else
      {
        await _protectedSessionStorage.DeleteAsync("UserSession");
        claimsPrincipal = _claimsPrincipal;
      }

      NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
  }
}
