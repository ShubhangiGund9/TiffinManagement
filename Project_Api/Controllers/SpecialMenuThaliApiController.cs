using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialMenuThaliApiController : BaseApiController
    {
        ISpecialMenuThaliService _specialMenuThali;
        public SpecialMenuThaliApiController(ISpecialMenuThaliService specialMenuThali)
        {
            _specialMenuThali = specialMenuThali;
        }

        

        [HttpGet]
        public async Task<List<TblSpecialMenuThali>> GetAllSpecialMenuThali()
        {
            var lst = await _specialMenuThali.GetAllSpecialMenuThalis();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddSpecial(CreateDtoSpeciaMenuThali p)
        {
            await _specialMenuThali.AddSpecialMenuThali(p);
            return ApiResponse(true, "SpecialMenuThali are Added", p);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateP(UpdateDtoSpeciaMenuThali p)
        {
            await _specialMenuThali.UpdateSpecialMenuThali(p);
            return ApiResponse(true, "SpecialMenuThali are Added", p);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialMenuThali(int id)
        {
            await _specialMenuThali.DeleteSpecialMenuThali(id);
            return ApiResponse(true, "SpecialMenuThali are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSpecialMenuThalibyId(int id)
        {
            var data = await _specialMenuThali.GetSpecialMenuThaliGetById(id);
            if (data == null)
                return ApiResponse(false, "SpecialMenuThali not found");

            return ApiResponse(true, "SpecialMenuThali fetched successfully", data);
        }
    }
}
