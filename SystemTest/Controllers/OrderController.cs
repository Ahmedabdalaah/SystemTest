using Microsoft.AspNetCore.Mvc;
using SystemTest.Models;
using SystemTest.Services;

namespace SystemTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMainRepository<Order> _repo;
        public OrderController(IMainRepository<Order> repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> FindAllOrder()
        {
            var order = await _repo.GetAll();
            return View(order);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrder()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(Order order)
        {
            if(ModelState.IsValid)
            {
                order.EmployeeId = 1;
                _repo.add(order);
                return RedirectToAction("FindAllOrder");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditOrder(int? id=7)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            var order = _repo.FindById(id);
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(Order order)
        {
            if(ModelState.IsValid)
            {
                order.Id = 7;
                order.EmployeeId = 1;
                _repo.update(order);
                return RedirectToAction("FindAllOrder");
            }
            else
            {
                return View(order);
            }
        }
        [HttpGet]
        public ActionResult DeleteOrder(int? id=6)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            var order = _repo.FindById(id);
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrder(Order order)
        {
            order.EmployeeId = 1;
            order.Id = 6;
            if(ModelState.IsValid)
            {
                _repo.delete(order);
                return RedirectToAction("FindAllOrder");
            }
            else
            {
                return View(order);
            }
        }
    }
}
