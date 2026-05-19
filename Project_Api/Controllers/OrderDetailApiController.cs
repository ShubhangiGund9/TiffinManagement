using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailApiController :BaseApiController
    {
        IOrderDetailService _orderDetailService;
        public OrderDetailApiController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public async Task<List<ResponseOrderDetail>>GetAllOrderDetail()
        {
            var lst = await _orderDetailService.GetAllOrderDetail();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(CreateDtoOderDetail c)
        {
            await _orderDetailService.AddOrderDetail(c);
            return ApiResponse(true, "OrderDetail are Added", c);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateDtoOrderDetailItem c)
        {
            await _orderDetailService.UpdateOrderDetail(c);
            return ApiResponse(true, "OrderDetails are updated", c);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _orderDetailService.DeleteOrderDetail(id);
            return ApiResponse(true, "OrderDetail are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrderDetailbyId(int id)
        {
            var data = await _orderDetailService.GetOrderDetail(id);    
            if (data == null)
                return ApiResponse(false, "OrderDetail not found");

            return ApiResponse(true, "OrderDetail fetched successfully", data);
        }


    }
}
