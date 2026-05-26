using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface IOrderDetailService
    {

        public Task<List<ResponseOrderDetail>> GetAllOrderDetail();
        public Task <ResponseOrderDetail> GetOrderDetail(int id);

        Task<int> AddOrderDetail(CreateDtoOderDetail orderDetail); 
        public Task DeleteOrderDetail(int id);

        public Task UpdateOrderDetail(UpdateDtoOrderDetailItem orderDetail);
        Task<List<ResponseOrderDetail>>GetOrdersByCustomer(int customerId);

    }
}
