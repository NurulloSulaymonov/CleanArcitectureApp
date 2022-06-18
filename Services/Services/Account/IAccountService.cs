using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Services.Account;

public interface IAccountService
{
    Task<List<IdentityUser>> GetUsers();
    public Task<IdentityUser?> Login(LoginDto login);
    Task<bool> Register(RegisterDto model);
}