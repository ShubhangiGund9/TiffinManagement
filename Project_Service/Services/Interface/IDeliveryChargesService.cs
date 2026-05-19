using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface IDeliveryChargesService
    {
        public Task<List<TblDeliveryCharges>> GetAllDeliveryCharges();

        Task<TblDeliveryCharges> GetDeliveryChargesById(int id);

        public Task AddDeliveryCharges(CreateDeliveryCharges deliveryCharges);
        public Task DeleteDeliveryCharges(int id);
        public Task UpdateDeliveryCharges(UpdateDeliveryCharges deliveryCharges);

    }
}
