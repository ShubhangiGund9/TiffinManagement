
using Project_Model.Models;

namespace Project_Service.Services.Interface
{
    public interface ICategoryService
    {

        Task <List<TblCategory>> GetCategories();

        Task<TblCategory> GetCategoryById (int id);

         Task AddCategories (CreateDtoCategory category);
        Task UpdateCategories (UpdateDtoCategory category);
        Task DeleteCategories (int id);


    }
}
