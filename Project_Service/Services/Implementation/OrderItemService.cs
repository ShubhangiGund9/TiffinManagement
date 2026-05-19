using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class OrderItemService:IOrderItemService
    {

        DapperContext _context;

        public OrderItemService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddOrderItem(CreateOrderItemDto item)
        {
            string query = @"Insert into TblOrderItem(Quantity,OrderDetail,Item)Values(@Quantity,@OrderDetail,@Item)";
            using(var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query,item);
            }

        }

        public async Task DeleteOrderItem(int id)
        {
            string query = @"Delete From TblOrderItem where OrderItemId=@id";
            using(var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResponseOrderItemDto>> GetAllOrderItem()
        {
            string query = @"select ot.OrderItemId,ot.Quantity,od.OrderDetailId,i.ItemId,i.ItemName
                            from TblOrderItem ot join TblOrderDetail od on ot.OrderDetail = od.OrderDetailId
                            join TblItem i on ot.Item = i.ItemId";
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<ResponseOrderItemDto>(query);
                return result.ToList();
            }
        }

        public async Task<ResponseOrderItemDto> GetOrderItemById(int id)
        {
            string query = @"select * from TblOrderItem ot join TblOrderDetail od on ot.OrderDetail=od.OrderDetailId
                           join TblItem i on ot.Item=i.ItemId where OrderItemId=@id";
            using(var con=_context.CreateConnection())
            {
                var result = await con.QueryFirstOrDefaultAsync<ResponseOrderItemDto>(query, new { Id = id });
                return result;
            }
        }

        public async Task UpdateOrderItem(UpdateOrderItemDto item)
        {
            string query = @"Update TblOrderItem set Quantity=@Quantity,OrderDetail=@OrderDetail,Item=@Item where OrderItemId=@OrderItemId";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, item);
            }
        }


        public async Task<List<ResponseOrderItemDto>>GetOrderItemsByOrderId(int id)
        {
            string query = @"select oi.OrderItemId,i.ItemName,oi.Quantity,i.Price from TblOrderItem oi join TblItem i on oi.Item = i.ItemId  where oi.OrderDetail = @Id";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<ResponseOrderItemDto>(query,new { Id = id });
                return result.ToList();
            }
        }
    }
}
