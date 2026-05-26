using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class OrderDetailController : Controller
    {
        IOrderDetailService _orderDetailService;
        IOrderItemService _orderItemService;
        public OrderDetailController(IOrderDetailService orderDetailService, IOrderItemService orderItemService)
        {
            _orderDetailService = orderDetailService;
            _orderItemService = orderItemService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _orderDetailService.GetAllOrderDetail();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromBody] UpdateDtoOrderDetailItem od
)
        {
            await _orderDetailService.UpdateOrderDetail(od);
            return Json("Status Updated Successfully");
        }

        public async Task<IActionResult> ViewItems(int id)
        {
            var data = await _orderItemService.GetOrderItemsByOrderId(id);
            return View(data);
        }


    }
}
