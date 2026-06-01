using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SpecialMenuThalisController : Controller
    {
        ISpecialMenuThaliService _specialMenuThaliService;
        IMenuThaliItemService _menuThaliItemService;
        IItemService _itemService;
        IWebHostEnvironment _env;

        public SpecialMenuThalisController(ISpecialMenuThaliService specialMenuThaliService, IMenuThaliItemService menuThaliItemService, IItemService itemService, IWebHostEnvironment env)
        {
            _specialMenuThaliService = specialMenuThaliService;
            _menuThaliItemService = menuThaliItemService;
            _itemService = itemService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["specialmenu"] = await _specialMenuThaliService.GetAllSpecialMenuThalis();
            ViewBag.items = new SelectList(await _itemService.GetAllItem(), "ItemId", "ItemName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] CreateDtoSpeciaMenuThali st)
        {
            int thaliId = await _specialMenuThaliService.AddSpecialMenuThali(st);
            foreach (var item in st.Items)
            {
                CreateDtoMenuthaliItem data = new CreateDtoMenuthaliItem()
                {
                    Thali = thaliId,
                    Item = item.ItemId,
                    Quantity = item.Quantity
                };
                await _menuThaliItemService.AddMenuThaliItem(data);
            }
            return Json("Saved Successfully");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);

                string folder =Path.Combine(_env.WebRootPath, "images");
                string path = Path.Combine(folder, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Json(fileName);
            }
            return Json("");
        }
    }
}