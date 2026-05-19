using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface ICustomerService
    {

        public Task<List<TblCustomer>> GetAllCustomer();
        Task <TblCustomer> GetCustomerById(int id);
        public Task AddCustomer(CreateDtoCustomer customer);

        public Task DeleteCustomer(int id);
        public Task UpdateCustomer(UpdateDtoCustomer customer);
    }
}
