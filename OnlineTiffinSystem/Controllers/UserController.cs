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
        IOrderItemService _orderItemService;
        IPaymentService _paymentService;
        IDeliveryChargesService _deliveryChargesService;
        IMenuThaliItemService _menuThaliItemService;
        public UserController(IItemService itemService, ICustomerService customerService, IOrderDetailService orderDetailService, ISpecialMenuThaliService specialMenuThaliService, IOrderItemService orderItemService, IPaymentService paymentService,IDeliveryChargesService deliveryChargesService,IMenuThaliItemService menuThaliItemService)
        {
            _itemService = itemService;
            _customerService = customerService;
            _orderDetailService = orderDetailService;
            _specialMenuThaliService = specialMenuThaliService;
            _orderItemService = orderItemService;
            _paymentService = paymentService;
            _deliveryChargesService = deliveryChargesService;
            _menuThaliItemService = menuThaliItemService;
        }
        public async Task<IActionResult> Menu()
        {
            var data = await _itemService.GetAllItem();
            ViewBag.special = await _specialMenuThaliService.GetAllSpecialMenuThalis();
            return View(data);
        }

        public async Task<IActionResult> Cart()
        {
            var charge =
            (await _deliveryChargesService
            .GetAllDeliveryCharges())
            .FirstOrDefault();

            ViewBag.DeliveryCharge = charge.Charges;

            return View();
        }
        public async Task <IActionResult> Checkout()
        {
           var charge =(await _deliveryChargesService.GetAllDeliveryCharges()).FirstOrDefault();

            ViewBag.DeliveryCharge = charge.Charges;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] CreateDtoOderDetail od)
        {
            var customers = await _customerService.GetAllCustomer();
            var charge =(await _deliveryChargesService.GetAllDeliveryCharges()).FirstOrDefault();
            Console.WriteLine(User.Identity.Name);

            var customer = customers.FirstOrDefault(x =>
            x.EmailAddress == User.Identity.Name);
            od.Customer = customer.CustomerId;
            od.OrderStatus = "Pending";
            od.Charge = charge.ChargeId;
            od.ExtraCharges = charge.Charges;
            od.Discount = 0;
            var orderId = await _orderDetailService.AddOrderDetail(od);

            CreatePaymentDto payment = new CreatePaymentDto();
            payment.OrderDetail = orderId;
            payment.PatymentMode = od.PatymentMode;
            payment.PaymentDescription = "Payment Successful";
            payment.TotalAmount = od.TotalAmount;

            await _paymentService.AddPayment(payment);
            foreach (var item in od.Items)
            {
                var thaliItems =await _menuThaliItemService.GetMenuThaliItemsByThaliId(item.ItemId);

                if (thaliItems.Any())
                {
                    foreach (var t in thaliItems)
                    {
                        CreateOrderItemDto oi =new CreateOrderItemDto();
                        oi.OrderDetail = orderId;
                        oi.Item = t.Item;
                        oi.Quantity = t.Quantity * item.Qty;
                        await _orderItemService.AddOrderItem(oi);
                    }
                }
                else
                {
                    CreateOrderItemDto oi =new CreateOrderItemDto();

                    oi.OrderDetail = orderId;
                    oi.Item = item.ItemId;
                    oi.Quantity = item.Qty;

                    await _orderItemService.AddOrderItem(oi);
                }
            }
            return Json("Order Saved Successfully");
        }

        public async Task<IActionResult>MyOrders()
        {
            var customers =await _customerService.GetAllCustomer();
            var customer = customers.FirstOrDefault(x => x.EmailAddress == User.Identity.Name);
            ViewBag.OrderItems =await _orderItemService.GetAllOrderItem();
            var data =await _orderDetailService.GetOrdersByCustomer(customer.CustomerId);
            return View(data);
        }

    }
}
