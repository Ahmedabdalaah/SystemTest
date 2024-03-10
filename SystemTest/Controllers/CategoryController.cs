using Microsoft.AspNetCore.Mvc;
using SystemTest.Models;
using SystemTest.Services;

namespace SystemTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMainRepository<Category> _repo;
        public CategoryController(IMainRepository<Category> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> FindAll()
        {
            return View(_repo.GetAll());
        }
    }
}
