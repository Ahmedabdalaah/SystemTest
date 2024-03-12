using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SystemTest.Models;
using SystemTest.Services;

namespace SystemTest.Controllers
{

    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly IMainRepository<Category> _repo;
        public CategoryController(IMainRepository<Category> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> FindAll()
        {
            var categories= await _repo.GetAll();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _repo.add(category);
                return RedirectToAction("FindAll");
            }
            else
            {
                return View(category);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory(int? id)
        {
            if( id==0 || id == null)
            {
                return NotFound();
            }
            var category=_repo.FindById(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                 _repo.update(category);
                return RedirectToAction("FindAll");
            }
            else
            {
                return View(category);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var category = _repo.FindById(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _repo.delete(category);
                return RedirectToAction("FindAll");
            }
            else
            {
                return View(category);
            }
        }
    }
}
