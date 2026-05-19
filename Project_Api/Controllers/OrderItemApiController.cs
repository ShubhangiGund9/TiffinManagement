using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemApiController : BaseApiController
    {
        IOrderItemService _orderItemService;
        public OrderItemApiController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        [HttpGet]
        public async Task<List<ResponseOrderItemDto>> GetAllOrderItem()
        {
            var lst = await _orderItemService.GetAllOrderItem();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem(CreateOrderItemDto oi)
        {
            await _orderItemService.AddOrderItem(oi);
            return ApiResponse(true, "OrderItem are Added", oi);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemDto c)
        {
            await _orderItemService.UpdateOrderItem(c);
            return ApiResponse(true, "OrderItem are updated", c);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _orderItemService.DeleteOrderItem(id);
            return ApiResponse(true, "OrderItem are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrderItembyId(int id)
        {
            var data = await _orderItemService.GetOrderItemById(id);
            if (data == null)
                return ApiResponse(false, "OrderItem not found");

            return ApiResponse(true, "OrderItem fetched successfully", data);
        }


    }
}
