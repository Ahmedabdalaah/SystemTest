using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SystemTest.Data;
using SystemTest.Models;
using SystemTest.Services;

namespace SystemTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMainRepository<Employee> _repo;
        public EmployeeController(IMainRepository<Employee> repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> FindAllEmp()
        {
            var employee = await _repo.GetAll();
            return View(employee);
        }
        [HttpGet]
        public async Task<ActionResult> AddEmployee()
        {
            SelectList catItem = _repo.select();
            ViewBag.catItem = catItem;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repo.add(employee);
                return RedirectToAction("FindAllEmp");
            }
            else
            {
                return View(employee);
            }
        }
        [HttpGet]
        public async Task<ActionResult> EditEmployee(int? id)
        {
            SelectList catItem = _repo.select();
            ViewBag.catItem = catItem;
            if (id==0 || id == null)
            {
                return NotFound();
            }
            var employee = _repo.FindById(id);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditEmployee(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _repo.update(employee);
                return RedirectToAction("FindAllEmp");
            }
            else
            {
                return View(employee);
            }
        }
    }
}
