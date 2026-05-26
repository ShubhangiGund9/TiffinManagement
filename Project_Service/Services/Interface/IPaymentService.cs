using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface IPaymentService
    {     
            Task<List<ResponsePaymentDto>> GetAllPayments();
            Task<ResponsePaymentDto> GetPaymentById(int id);
            Task AddPayment(CreatePaymentDto payment);
        }
    }
