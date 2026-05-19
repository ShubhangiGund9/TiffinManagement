using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface IPaymentService
    {

        public Task<List<ResponsePaymentDto>> GetAllPayment();
        public Task<ResponsePaymentDto> GetPaymentById(int id);

        public Task DeletePayment(int id);
        public Task UpdatePayment(UpdatePaymentDto payment);

        public Task AddPayment(CreatePaymentDto payment);

    }
}
