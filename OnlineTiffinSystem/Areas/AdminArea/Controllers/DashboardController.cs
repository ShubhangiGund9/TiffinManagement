using Microsoft.AspNetCore.Mvc;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DashboardController : Controller
    {
        ICustomerService _customerService;
        IItemService _itemService;
        IOrderDetailService _orderDetailService;

        public DashboardController(ICustomerService customerService,IItemService itemService,IOrderDetailService orderDetailService)
        {
            _customerService = customerService;
            _itemService = itemService;
            _orderDetailService = orderDetailService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomer();
            var items = await _itemService.GetAllItem();
            var orders =await _orderDetailService.GetAllOrderDetail();
            ViewBag.TotalCustomers =customers.Count();
            ViewBag.TotalItems =items.Count();
            ViewBag.TotalOrders =orders.Count();
            ViewBag.PendingOrders =orders.Count(x =>x.OrderStatus == "Pending");
            ViewBag.DeliveredOrders =orders.Count(x =>x.OrderStatus == "Delivered");
            return View();
        }
    }
}