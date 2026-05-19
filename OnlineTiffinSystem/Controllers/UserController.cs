using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Controllers
{
    public class UserController : Controller
    {
        IItemService _itemService;
        ICustomerService _customerService;
        IOrderDetailService _orderDetailService;
        ISpecialMenuThaliService _specialMenuThaliService;

        public UserController(IItemService itemService, ICustomerService customerService, IOrderDetailService orderDetailService, ISpecialMenuThaliService specialMenuThaliService)
        {
            _itemService = itemService;
            _customerService = customerService;
            _orderDetailService = orderDetailService;
            _specialMenuThaliService = specialMenuThaliService;
        }
        public async Task<IActionResult> Menu()
        {
            var data = await _itemService.GetAllItem();
            ViewBag.special =    await _specialMenuThaliService
    .GetAllSpecialMenuThalis();
            return View(data);
        }

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] CreateDtoOderDetail od)
        {
            var customers =await _customerService.GetAllCustomer();
            var customer = customers.FirstOrDefault(x =>
            x.EmailAddress == User.Identity.Name);
            od.Customer = customer.CustomerId;
            od.OrderStatus = "Pending";
            od.Charge = 1;
            od.ExtraCharges = 40;
            od.Discount = 0;
            await _orderDetailService.AddOrderDetail(od);

            return Json("Order Saved Successfully");
        }


    }
}
