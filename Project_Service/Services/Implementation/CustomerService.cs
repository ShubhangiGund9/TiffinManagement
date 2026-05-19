using Dapper;

using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class CustomerService : ICustomerService
    {

        DapperContext _context;
        public CustomerService(DapperContext context) 
            {
                _context = context;
            }
        
        public async Task AddCustomer(CreateDtoCustomer customer)
        {
            string query = @"Insert into TblCustomer(CustomerName,EmailAddress,CustomerAddress, MobileNo,Password)
                             Values(@CustomerName,@EmailAddress,@CustomerAddress,@MobileNo,@Password)";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,customer);
            }


        }

        public async Task DeleteCustomer(int id)
        {
            string query = @"Delete from TblCustomer where CustomerId=@id";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<TblCustomer>> GetAllCustomer()
        {
            string query = @"Select * from TblCustomer";
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<TblCustomer>(query);
                return result.ToList();
            }

        }

        public async Task<TblCustomer> GetCustomerById(int id)
        {
            string query = @"Select * from TblCustomer where CustomerId=@id";
            using(var con = _context.CreateConnection())
            {
                var result=await con.QueryFirstOrDefaultAsync<TblCustomer>(query, new {Id=id});
                return result;
            }
        }

        public async Task UpdateCustomer(UpdateDtoCustomer customer)
        {
            string query = @"update TblCustomer set CustomerName=@CustomerName,
                                                    EmailAddress=@EmailAddress,
                                                    CustomerAddress=@CustomerAddress,
                                                    MobileNo=@MobileNo,
                                                    Password=@Password where CustomerId=@CustomerId";
            using(var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,customer);
            }

        }
    }
}
