using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface IItemService
    {

        Task<List<ResponseItemDto>> GetAllItem();
        Task<ResponseItemDto> GetItemById(int id);

        Task AddItem(CreateDtoItem item);
        Task DeleteItem(int id);
        Task UpdateItem(UpdateDtoItem item);
    }
}
