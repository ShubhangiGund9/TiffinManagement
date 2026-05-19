using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoriesController : Controller
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["categories"] = await _categoryService.GetCategories();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateDtoCategory c)
        {
            await _categoryService.AddCategories(c);
            ViewData["categories"] = await _categoryService.GetCategories();

            ModelState.Clear();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult>Delete(int id)
        {
            await _categoryService.DeleteCategories(id);
            return RedirectToAction("Index");
        }
    }
}
