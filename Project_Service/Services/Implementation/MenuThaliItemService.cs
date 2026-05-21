using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class MenuThaliItemService : IMenuThaliItemService
    {
        DapperContext _context;
        public MenuThaliItemService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddMenuThaliItem(CreateDtoMenuthaliItem item)
        {
            string query = @"Insert into TblMenuThaliItem(Thali,Item,Quantity) values(@Thali,@Item,@Quantity)";
            using(var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query,item);  
            }
        }

        public async Task DeleteMenuThaliItem(int id)
        {
            string query = @"Delete from TblMenuThaliItem where ThaliItemId=@id";
            using( var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResponseMenuThaliItemDto>> GetAllMenuThaliItem()
        {
            string query = @"SELECT mt.ThaliItemId,smt.Title,i.ItemName,mt.Quantity
                           FROM TblMenuThaliItem mt JOIN TblSpecialMenuThali smt
                           ON mt.Thali = smt.ThaliId JOIN TblItem i ON mt.Item = i.ItemId";
            using (var con = _context.CreateConnection())
            {
                var result=await con.QueryAsync<ResponseMenuThaliItemDto>(query);
                return result.ToList();
            }
        }

        public async Task<ResponseMenuThaliItemDto> GetMenuThaliItemById(int id)
        {
            string query = @"SELECT mt.ThaliItemId,smt.Title,i.ItemName,mt.Quantity
                FROM TblMenuThaliItem mt JOIN TblSpecialMenuThali smt
                ON mt.Thali = smt.ThaliId JOIN TblItem i ON mt.Item = i.ItemId where ThaliItemId=@id";
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryFirstOrDefaultAsync<ResponseMenuThaliItemDto>(query,new {Id=id});
                return result;
            }
        }

        public async Task UpdatMenuThaliItem(UpdateMenuthaliItem item)
        {
            string query = @"Update TblMenuThaliItem set Thali=@Thali,Item=@Item,Quantity=@Quantity where ThaliItemId=@ThaliItemId";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,item);
            }
        }
    }
}
