using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using SystemTest.Models;
using SystemTest.Services;

namespace SystemTest.Controllers
{
    public class CustomController : Controller
    {
        private readonly IMainRepository<Order> _repo;
        public CustomController(IMainRepository<Order> repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(int? id)
        {
            id = Int32.Parse(HttpContext.Request.Form["firstname"].ToString());
            var employee = _repo.GetByPhone(x => x.EmployeeId == id);
            if(employee != null)
            {
                Order rec = new Order
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Description = employee.Description
                };

                ViewBag.Message = rec;
            }
           
            return View();
        }
    }
}
