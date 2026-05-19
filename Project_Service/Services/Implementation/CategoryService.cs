using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class CategoryService:ICategoryService
    {

        DapperContext _context;

        public CategoryService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddCategories(CreateDtoCategory category)
        {
            string query = @"Insert into TblCategory(CategoryName) values(@CategoryName)";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, category);
            }
        }

        public async Task DeleteCategories(int id)
        {
            string query = @"Delete from TblCategory where CategoryId=@id";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<TblCategory>> GetCategories()
        {
            string query = @"Select * from TblCategory";
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<TblCategory>(query);
                return result.ToList();

            }
        }

        public async Task<TblCategory> GetCategoryById(int id)
        {
            string query= @"Select * from TblCategory where CategoryId=@id";
            using(var con = _context.CreateConnection())
            {
                var result=await con.QueryFirstOrDefaultAsync<TblCategory>(query, new {Id=id});
                return result;
            }
        }

        public async Task UpdateCategories(UpdateDtoCategory category)
        {

            string query = @"Update TblCategory set CategoryName=@CategoryName where CategoryId=@CategoryId";
             using( var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, category);
            }
        }
    }
}
