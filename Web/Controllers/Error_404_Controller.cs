using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class Error_404_Controller : Controller
    {
        public IActionResult Page_404()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}
