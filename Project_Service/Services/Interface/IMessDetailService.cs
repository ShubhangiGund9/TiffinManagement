


using Project_Model.Models;

namespace Project_Service.Services.Interface
{

    public interface IMessDetailService
        {
            Task<List<TblMessDetail>> GetAllMessDetails();

            Task<TblMessDetail> GetMessDetailById(int id);

            Task AddMessDetail(CreateDtoMessDetail messDetail);

            Task UpdateMessDetail(UpdateDtoMessDetail messDetail);

            Task DeleteMessDetail(int id);
        }
    }
