using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class PaymentService : IPaymentService
    {
        DapperContext _context;

        public PaymentService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddPayment(CreatePaymentDto payment)
        {
            string query = @"Insert into TblPayment(OrderDetail,PatymentMode,PaymentDescription,TotalAmount)values(@OrderDetail,@PatymentMode,@PaymentDescription,@TotalAmount)";

            using (var con =_context.CreateConnection())
            {
                await con.ExecuteAsync(query,payment);
            }
        }

        public async Task<List<ResponsePaymentDto>>
        GetAllPayments()
        {
            string query = @"select p.PaymentId,p.PatymentMode,p.PaymentDescription,p.TotalAmount,od.OrderDetailId,od.OrderStatus,od.PinCode,od.DeliveryAddress,od.OrderAt,od.DeliveryAt,od.Landmark,od.ExtraCharges,od.Discount,c.CustomerName,c.MobileNo,c.EmailAddress from TblPayment p join TblOrderDetail od on p.OrderDetail = od.OrderDetailId join TblCustomer c on od.Customer =c.CustomerId";

            using (var con = _context.CreateConnection())
            {
                var result =await con.QueryAsync<ResponsePaymentDto>(query);
                return result.ToList();
            }
        }

        public async Task<ResponsePaymentDto>
        GetPaymentById(int id)
        {
            string query = @"select p.PaymentId,p.PatymentMode,p.PaymentDescription,p.TotalAmount,od.OrderDetailId,od.OrderStatus,c.CustomerName,c.MobileNo,c.EmailAddress
            from TblPayment p join TblOrderDetail od on p.OrderDetail = od.OrderDetailId join TblCustomer c on od.Customer =c.CustomerId where p.PaymentId = @Id";

            using (var con =_context.CreateConnection())
            {
                var result =await con.QueryFirstOrDefaultAsync<ResponsePaymentDto>(query,new { Id = id });
                return result;
            }
        }
    }
}