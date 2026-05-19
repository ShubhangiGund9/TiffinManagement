using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface ISpecialMenuThaliService
    {
        Task<List<ResponseSpecialThaliDto>>GetAllSpecialMenuThalis(); 
        public Task<TblSpecialMenuThali> GetSpecialMenuThaliGetById(int id);
        //public Task AddSpecialMenuThali(CreateDtoSpeciaMenuThali specialMenuThali);

        public Task<int> AddSpecialMenuThali(CreateDtoSpeciaMenuThali specialMenuThali);
        public Task DeleteSpecialMenuThali(int id);
        public Task UpdateSpecialMenuThali(UpdateDtoSpeciaMenuThali specialMenuThali);
    }
}
