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
            id = Int32.Parse(HttpContext.Request.Form["code"].ToString());
            var order = _repo.GetByPhone(x => x.EmployeeId == id);
            if(order != null)
            {
                Order rec = new Order
                {
                    Id = order.Id,
                    Name = order.Name,
                    Description = order.Description,
                    EmployeeId = order.EmployeeId
                };

                ViewBag.Message = rec;
            }
           
            return View();
        }
    }
}
