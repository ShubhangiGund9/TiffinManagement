using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DeliveryChargesController : Controller
    {

        IDeliveryChargesService _deliveryChargesService;
        public DeliveryChargesController(IDeliveryChargesService deliveryChargesService)
        {
            _deliveryChargesService = deliveryChargesService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["deliverycharge"]=await _deliveryChargesService.GetAllDeliveryCharges();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateDeliveryCharges dc)
        {
            await _deliveryChargesService.AddDeliveryCharges(dc);
            return RedirectToAction("Index");
        }
    }
}
