using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Account;

namespace Web.Controllers;

public class AcccountController:Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IAccountService _accountService;

    public AcccountController(SignInManager<IdentityUser> signInManager, IAccountService accountService)
    {
        _signInManager = signInManager;
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Login(string ReturnUrl)
    {
        return View(new LoginDto() { ReturnUrl = ReturnUrl });
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto login)
    {
        if (ModelState.IsValid)
        {
            var user = await _accountService.Login(login);

            if (user == null) return View(login);

            await _signInManager.SignInAsync(user,false,null);

            return RedirectToAction("Index","Home", new {area = "Admin"});
        }
    }
    
    
}