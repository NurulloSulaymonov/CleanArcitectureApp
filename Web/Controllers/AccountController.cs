using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Account;

namespace Web.Controllers;

public class AccountController:Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IAccountService _accountService;

    public AccountController(SignInManager<IdentityUser> signInManager, IAccountService accountService)
    {
        _signInManager = signInManager;
        _accountService = accountService;
    }
    public async Task<IActionResult> GetUsers()
    {
        var listOfUsers = await _accountService.GetUsers();
        return View(listOfUsers);
    }


    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginDto() { ReturnUrl = returnUrl });
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
        return View(login);
    }
    
    
    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterDto() );
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto register)
    {
        if (ModelState.IsValid)
        {
            var registered = await _accountService.Register(register);

            if (registered == false) return View(register);
            
            return RedirectToAction("Login","Account");
        }

        return View(register);
    }
    
    
}