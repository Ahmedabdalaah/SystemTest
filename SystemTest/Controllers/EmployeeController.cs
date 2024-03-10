using Microsoft.AspNetCore.Mvc;

namespace SystemTest.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
