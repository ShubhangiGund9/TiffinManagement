using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class MenuThaliItemsController : Controller
    {

        IMenuThaliItemService _menuThaliItemService;
        IItemService _itemService;
        ISpecialMenuThaliService _specialMenuThaliService;
        public MenuThaliItemsController(IMenuThaliItemService menuThaliItemService, IItemService itemService, ISpecialMenuThaliService specialMenuThaliService)
        {
            _menuThaliItemService = menuThaliItemService;
            _itemService = itemService;
            _specialMenuThaliService = specialMenuThaliService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["menuitem"] = await _menuThaliItemService.GetAllMenuThaliItem();
            ViewBag.items = new SelectList(await _itemService.GetAllItem(), "ItemId", "ItemName");
            ViewBag.specialmenu = new SelectList(await _specialMenuThaliService.GetAllSpecialMenuThalis(), "ThaliId", "Title");
            return View();
        }

    }
}
