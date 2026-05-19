using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class MessDetailsController : Controller
    {
        IMessDetailService _messDetailService;
        public MessDetailsController(IMessDetailService messDetailService)
        {
            _messDetailService = messDetailService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["mess"] = await _messDetailService.GetAllMessDetails();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateDtoMessDetail md)
        {
            await _messDetailService.AddMessDetail(md);
            ViewData["mess"] = await _messDetailService.GetAllMessDetails();

            return RedirectToAction("Index");
        }
    }
}
