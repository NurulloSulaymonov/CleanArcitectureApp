using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Area.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class HomeController:Controller
{
    public HomeController()
    {
        
    }

    public IActionResult Index()
    {
        return View();
    }
    
}