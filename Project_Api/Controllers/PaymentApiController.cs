//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Project_Model.Models;
//using Project_Service.Services.Implemenation;
//using Project_Service.Services.Interface;

//namespace Project_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaymentApiController : BaseApiController
//    {

//        IPaymentService _paymentService;
//        public PaymentApiController(IPaymentService paymentService)
//        {
//            _paymentService = paymentService;
//        }

//        [HttpGet]
//        public async Task<List<ResponsePaymentDto>> GetAllPayment()
//        {
//            var lst = await _paymentService.GetAllPayment();
//            return lst;
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddPayment(CreatePaymentDto p)
//        {
//            await _paymentService.AddPayment(p);
//            return ApiResponse(true, "Payments are Added", p);
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdatePayment(UpdatePaymentDto p)
//        {
//            await _paymentService.UpdatePayment(p);
//            return ApiResponse(true, "Payments are Added", p);
//        }

//        [HttpDelete]
//        public async Task<IActionResult> DeletePayment(int id)
//        {
//            await _paymentService.DeletePayment(id);
//            return ApiResponse(true, "Items are deleted");
//        }

//        [HttpGet("{id}")]

//        public async Task<IActionResult> GetPaymentbyId(int id)
//        {
//            var data = await _paymentService.GetPaymentById(id);
//            if (data == null)
//                return ApiResponse(false, "Item not found");

//            return ApiResponse(true, "Item fetched successfully", data);
//        }

//    }
//}
