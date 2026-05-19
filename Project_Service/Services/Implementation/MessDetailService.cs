using Dapper;

using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class MessDetailService : IMessDetailService
    {
         DapperContext _context;

        public MessDetailService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<TblMessDetail>> GetAllMessDetails()
        {
            string query = "select * from TblMessDetail";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<TblMessDetail>(query);
                return result.ToList();
            }
        }

        public async Task<TblMessDetail> GetMessDetailById(int id)
        {
            string query = "select * from TblMessDetail where MessId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<TblMessDetail>(query,new { Id = id });


                return result;
            }
        }

        public async Task AddMessDetail(CreateDtoMessDetail messDetail)
        {
            string query = @"insert into TblMessDetail
                            (MessName, OwnerName, Address, EmailAddress, Password, MobileNo, AlternativeNo)
                            values
                            (@MessName, @OwnerName, @Address, @EmailAddress, @Password, @MobileNo, @AlternativeNo)";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, messDetail);
            }
        }

        public async Task UpdateMessDetail(UpdateDtoMessDetail messDetail)
        {
            string query = @"update TblMessDetail
                             set MessName = @MessName,
                                 OwnerName = @OwnerName,
                                 Address = @Address,
                                 EmailAddress = @EmailAddress,
                                 Password = @Password,
                                 MobileNo = @MobileNo,
                                 AlternativeNo = @AlternativeNo
                             where MessId = @MessId";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, messDetail);
            }
        }

        public async Task DeleteMessDetail(int id)
        {
            string query = @"Delete from TblMessDetail where MessId = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}