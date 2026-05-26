using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface IOrderItemService
    {

        public Task<List<ResponseOrderItemDto>> GetAllOrderItem();
        public Task<ResponseOrderItemDto> GetOrderItemById(int id);

        public Task AddOrderItem(CreateOrderItemDto item);
        public Task DeleteOrderItem(int id);
        public Task UpdateOrderItem(UpdateOrderItemDto item);
        public Task<List<ResponseOrderItemDto>> GetOrderItemsByOrderId(int id);

    }
}
