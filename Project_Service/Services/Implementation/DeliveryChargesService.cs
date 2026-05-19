using Dapper;

using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class DeliveryChargesService:IDeliveryChargesService
    {

        DapperContext _context;
        public DeliveryChargesService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddDeliveryCharges(CreateDeliveryCharges deliveryCharges)
        {
            string query = @"insert into TblDeliveryCharges(ChargesFor,Charges) Values(@ChargesFor,@Charges)";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,deliveryCharges);
            }
        }

        public async Task DeleteDeliveryCharges(int id)
        {
            string query = @"Delete From TblDeliveryCharges where ChargeId=@id";
            using(var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<TblDeliveryCharges>> GetAllDeliveryCharges()
        {
            string query = @"Select * from TblDeliveryCharges";
            using(var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<TblDeliveryCharges>(query);
                return result.ToList();
            }
        }

        public async Task<TblDeliveryCharges> GetDeliveryChargesById(int id)
        {
            string query = @"select * from TblDeliveryCharges where ChargeId=@id";
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryFirstOrDefaultAsync<TblDeliveryCharges>(query, new { Id = id });
                return result;
            }
        }

        public async Task UpdateDeliveryCharges(UpdateDeliveryCharges deliveryCharges)
        {
            string query = @"Update TblDeliveryCharges set ChargesFor=@ChargesFor,Charges=@Charges where ChargeId=@ChargeId";
            using(var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,deliveryCharges);
            }
        }
    }
}
