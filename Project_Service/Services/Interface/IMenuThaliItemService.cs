using OnlineTiffinSystem.Models;
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface IMenuThaliItemService
    {

        public Task<List<ResponseMenuThaliItemDto>> GetAllMenuThaliItem();
        public Task<ResponseMenuThaliItemDto> GetMenuThaliItemById(int id);
        public Task AddMenuThaliItem(CreateDtoMenuthaliItem item);
        public Task DeleteMenuThaliItem(int id);
        public Task UpdatMenuThaliItem(UpdateMenuthaliItem item);
    }
}
