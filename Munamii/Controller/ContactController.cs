using Microsoft.AspNetCore.Mvc;

namespace Munamii.Controller;

public class ContactController : Microsoft.AspNetCore.Mvc.Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}