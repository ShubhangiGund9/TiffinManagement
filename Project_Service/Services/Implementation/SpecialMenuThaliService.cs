using Dapper;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Service.Services.Implemenation
{
    public class SpecialMenuThaliService:ISpecialMenuThaliService
    {
        DapperContext _context;
        public SpecialMenuThaliService(DapperContext context)
        {
            _context = context;
        }

        //public async Task AddSpecialMenuThali(CreateDtoSpeciaMenuThali specialMenuThali)
        //{
        //    string query = @"insert into TblSpecialMenuThali(Title,Amount,Discount) values(@Title,@Amount,@Discount)";
        //    using (var con = _context.CreateConnection())
        //    {
        //        await con.ExecuteAsync(query,specialMenuThali);
        //    }
        // }

        public async Task<int> AddSpecialMenuThali(CreateDtoSpeciaMenuThali specialMenuThali)
        {
            string query =@"insert into TblSpecialMenuThali(Title,Amount,Discount,ThaliPhoto)output inserted.ThaliId values(@Title,@Amount,@Discount,@ThaliPhoto)";

            using (var con = _context.CreateConnection())
            {
                int id = await con.ExecuteScalarAsync<int>(query,specialMenuThali);
                return id;
            }
        }

        public async Task DeleteSpecialMenuThali(int id)
        {
            string query = @"Delete from TblSpecialMenuThali where ThaliId=@id";
            using(var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, new { Id = id });
            }
        }
        public async Task<List<ResponseSpecialThaliDto>>GetAllSpecialMenuThalis()
        {
            string query = @"select s.ThaliId,s.Title,s.Amount,s.Discount,s.ThaliPhoto,i.ItemName from TblSpecialMenuThali s
                            inner join TblMenuthaliItem mt
                            on s.ThaliId = mt.Thali inner join TblItem i
                            on mt.Item = i.ItemId";

            using (var con = _context.CreateConnection())
            {
                var data =await con.QueryAsync(query);

                List<ResponseSpecialThaliDto> result =new List<ResponseSpecialThaliDto>();

                foreach (var item in data)
                {
                    var existing =result.FirstOrDefault(x =>x.ThaliId == item.ThaliId);
                    if (existing == null)
                    {
                        ResponseSpecialThaliDto t =new ResponseSpecialThaliDto();

                        t.ThaliId = item.ThaliId;
                        t.Title = item.Title;
                        t.Amount = item.Amount;
                        t.Discount = item.Discount;
                        t.ThaliPhoto = item.ThaliPhoto;
                        t.Items = new List<string>();
                        t.Items.Add(item.ItemName);
                        result.Add(t);
                    }
                    else
                    {
                        existing.Items.Add(item.ItemName);
                    }
                }

                return result;
            }
        }

        public async Task<TblSpecialMenuThali> GetSpecialMenuThaliGetById(int id)
        {
            string query = @"select * from TblSpecialMenuThali where ThaliId=@id";
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryFirstOrDefaultAsync<TblSpecialMenuThali>(query,new {Id=id});
                return result;
            }
        }
        

        public async Task UpdateSpecialMenuThali(UpdateDtoSpeciaMenuThali specialMenuThali)
        {
            string query = @"Update TblSpecialMenuThali set Title=@Title,Amount=@Amount,Discount=@Discount,ThaliPhoto=@ThaliPhoto where ThaliId=@ThaliId";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,specialMenuThali);
            }
        }
    }
}
