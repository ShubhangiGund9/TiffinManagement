using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class ItemService:IItemService
    {

        DapperContext _context;

        public ItemService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddItem(CreateDtoItem item)
        {
            string query = @"Insert into TblItem(ItemName,Category,Price,Description,IsVegeterian,Tax,ItemPhoto)Values(@ItemName,@Category,@Price,@Description,@IsVegeterian,@Tax,@ItemPhoto)";
            using(var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query, item);
            }
            
                 }

        public async Task DeleteItem(int id)
        {
            string query = @"Delete From TblItem where ItemId=@id";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResponseItemDto>> GetAllItem()
        {
            string query = @"Select * from TblItem e inner join TblCategory c on e.Category = c.CategoryId";
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<ResponseItemDto>(query);
                return result.ToList();
            }
        }


        public async Task<ResponseItemDto> GetItemById(int id)
        {
            string query = @"Select * from TblItem e
                     inner join TblCategory c
                     on e.Category = c.CategoryId
                     where ItemId=@id";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryFirstOrDefaultAsync<ResponseItemDto>(
                                query,
                                new { Id = id });

                return result;
            }
        }

        public async Task UpdateItem(UpdateDtoItem item)
        {
            string query = @"Update TblItem set ItemName=@ItemName,Category=@Category,Price=@Price,Description=@description,IsVegeterian=@IsVegeterian, Tax=@Tax,ItemPhoto=@ItemPhoto where ItemId=@ItemId";
            using( var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query, item);
            }
        }
    }
}
