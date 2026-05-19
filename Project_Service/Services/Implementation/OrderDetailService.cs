using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class OrderDetailService:IOrderDetailService
    {
        DapperContext _context;
        public OrderDetailService(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddOrderDetail
  (
      CreateDtoOderDetail orderDetail
  )
        {
            string query = @"

    Insert into TblOrderDetail
    (
        Customer,
        OrderStatus,
        PinCode,
        DeliveryAddress,
        TotalAmount,
        Landmark,
        ExtraCharges,
        Discount,
        Charge
    )

    output inserted.OrderDetailId

    Values
    (
        @Customer,
        @OrderStatus,
        @PinCode,
        @DeliveryAddress,
        @TotalAmount,
        @Landmark,
        @ExtraCharges,
        @Discount,
        @Charge
    )";

            using (var con = _context.CreateConnection())
            {
                int id =
                await con.ExecuteScalarAsync<int>
                (
                    query,
                    orderDetail
                );

                return id;
            }
        }

        public async Task DeleteOrderDetail(int id)
        {
            string query = "Delete From TblOrderDetail where OrderDetailId=@id";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResponseOrderDetail>> GetAllOrderDetail()
        {
            string query = @"Select od.OrderDetailId,c.CustomerName, od.OrderStatus,od.PinCode,od.DeliveryAddress,
                           od.OrderAt,od.DeliveryAt,od.TotalAmount,od.Landmark,od.ExtraCharges,
                          od.Discount,dc.ChargesFor from TblOrderDetail od join TblCustomer c 
                           on od.Customer = c.CustomerId
                          join TblDeliveryCharges dc on od.Charge = dc.ChargeId";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<ResponseOrderDetail>(query);
                return result.ToList();
            }
        }

        public async Task<ResponseOrderDetail> GetOrderDetail(int id)
        {
            string query = @"Select od.OrderDetailId, c.CustomerName, od.OrderStatus,od.PinCode,od.DeliveryAddress,
                           od.OrderAt,od.DeliveryAt,od.TotalAmount,od.Landmark,od.ExtraCharges,
                          od.Discount,dc.ChargesFor from TblOrderDetail od join TblCustomer c 
                           on od.Customer = c.CustomerId
                          join TblDeliveryCharges dc on od.Charge = dc.ChargeId Where OrderDetailId=@Id";
            using( var con = _context.CreateConnection())
            {
                var result=await con.QueryFirstOrDefaultAsync<ResponseOrderDetail>(query, new {Id=id});
                return result;
               
            }
        }

        public async Task UpdateOrderDetail(UpdateDtoOrderDetailItem orderDetail)
        {
            string query = @"Update TblOrderDetail set OrderStatus = @OrderStatus Where OrderDetailId = @OrderDetailId";

            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,orderDetail);
            }
        }
    }
}
