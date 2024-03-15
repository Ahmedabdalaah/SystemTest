using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Data.Entity;
using System.Security.Principal;
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
        [Authorize(Roles = "Employee")]
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
                _repo.add(order);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditOrder(int? id)
        {
            if (id==0 || id == null)
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
                _repo.update(order);
                return RedirectToAction("Index");
            }
            else
            {
                return View(order);
            }
        }
        [HttpGet]
        public ActionResult DeleteOrder(int? id)
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
            if(ModelState.IsValid)
            {
                _repo.delete(order);
                return RedirectToAction("Index");
            }
            else
            {
                return View(order);
            }
        }
    }
}
