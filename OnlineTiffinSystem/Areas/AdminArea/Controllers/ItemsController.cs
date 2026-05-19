using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ItemsController : Controller
    {
        IItemService _itemService;
        ICategoryService _categoryService;
        IWebHostEnvironment _env;

        public ItemsController(IItemService itemService, ICategoryService categoryService,IWebHostEnvironment env)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.categories = new SelectList(await _categoryService.GetCategories(), "CategoryId", "CategoryName");
            ViewData["items"] = await _itemService.GetAllItem();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateDtoItem di, IFormFile photo)
        {
            string imgname = di.ItemName + Path.GetExtension(photo.FileName);
            string imgpath = _env.WebRootPath + "/images/" + imgname;
            FileStream fs = new FileStream(imgpath, FileMode.Create);
            photo.CopyTo(fs);
            fs.Close();
            di.ItemPhoto = imgname;
            await _itemService.AddItem(di);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ResponseItemDto i = await _itemService.GetItemById(id);

            CreateDtoItem di = new CreateDtoItem()
            {
                ItemId = i.ItemId,
                ItemName = i.ItemName,
                Category = i.Category,
                Price = i.Price,
                Description = i.Description,
                Tax = i.Tax,
                IsVegeterian = i.IsVegeterian,
                ItemPhoto = i.ItemPhoto
            };

            ViewBag.categories = new SelectList(await _categoryService.GetCategories(),
                "CategoryId",
                "CategoryName");

            ViewData["items"] = await _itemService.GetAllItem();

            return View("Index", di);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDtoItem di, IFormFile photo)
        {
            string imgname = di.ItemName + Path.GetExtension(photo.FileName);
            string imgpath = _env.WebRootPath + "/images/" + imgname;
            FileStream fs = new FileStream(imgpath, FileMode.Create);
            photo.CopyTo(fs);
            fs.Close();
            di.ItemPhoto = imgname;

            await _itemService.UpdateItem(di);

            ViewBag.categories = new SelectList(await _categoryService.GetCategories(),"CategoryId","CategoryName");
            ViewData["items"] = await _itemService.GetAllItem();
            ModelState.Clear();
            return View("Index");
        }




        public async Task<IActionResult>Delete(int id)
        {
            await _itemService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}