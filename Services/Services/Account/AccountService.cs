using System.Security.Claims;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Services.Account;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser?> Login(LoginDto login)
    {
        
        var user =  await _userManager.FindByNameAsync(login.Username);
        if (user == null) return null;
        
        var validatePassword = new PasswordValidator<IdentityUser>();
        var result = await  validatePassword.ValidateAsync(_userManager, user, login.Password);

      if (!result.Succeeded) return null;
      
        // fill claims
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };
        
        await _userManager.AddClaimsAsync(user, claims);

        return user;
    }

    public async Task<bool> Register(RegisterDto model)
    {
        var user = new IdentityUser()
        {
            Email = model.Email,
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user);

        return result.Succeeded;
    }
}