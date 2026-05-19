using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class PaymentService:IPaymentService
    {
        DapperContext _context;
        public PaymentService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddPayment(CreatePaymentDto payment)
        {
            string query = @"Insert into TblPayment(OrderDetail,PatymentMode,PaymentDescription,TotalAmount)Values(@OrderDetail,@PatymentMode,@PaymentDescription,@TotalAmount)";
            using(var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query,payment);

            }
        }

        public async Task DeletePayment(int id)
        {
            string query = @"Delete From TblPayment where PaymentId=@id";
            using(var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });

            }
        }

        public async Task<List<ResponsePaymentDto>> GetAllPayment()
        {
            string query = @"SELECT p.PaymentId, p.PatymentMode,p.PaymentDescription,
                           p.TotalAmount,o.OrderDetailId,o.OrderStatus,o.PinCode,o.DeliveryAddress,
                           o.OrderAt,o.DeliveryAt,o.Landmark,o.ExtraCharges,o.Discount,
                            c.CustomerName,c.MobileNo,c.EmailAddress FROM TblPayment p JOIN TblOrderDetail o
                            ON p.OrderDetail = o.OrderDetailId JOIN TblCustomer c
                          ON o.Customer = c.CustomerId";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<ResponsePaymentDto>(query);

                return result.ToList();
            }
        }
        public async Task<ResponsePaymentDto> GetPaymentById(int id)
        {
            string query = @"select * from TblPayment where PaymentId=@id";
            using( var con=_context.CreateConnection())
            {
                var result = await con.QueryFirstOrDefaultAsync<ResponsePaymentDto>(query, new { Id = id });

                return result;
                
            }
        }

        public async Task UpdatePayment(UpdatePaymentDto payment)
        {

            string query = @"Update TblPayment set OrderDetail=@OrderDetail,PatymentMode=@PatymentMode,PaymentDescription=@PaymentDescription,TotalAmount=@TotalAmount where PaymentId=@PaymentId";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,payment);
            }
        }
    }
}
