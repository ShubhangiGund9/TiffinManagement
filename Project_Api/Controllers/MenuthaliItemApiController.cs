using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuthaliItemApiController : BaseApiController
    {
        IMenuThaliItemService _menuThaliItemService;
        public MenuthaliItemApiController(IMenuThaliItemService menuThaliItemService)
        {
            _menuThaliItemService = menuThaliItemService;
        }


        [HttpGet]
        public async Task<List<ResponseMenuThaliItemDto>> GetAllMenuThaliItem()
        {
            var lst = await _menuThaliItemService.GetAllMenuThaliItem();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuThaliitem(CreateDtoMenuthaliItem mt)

        {
            await _menuThaliItemService.AddMenuThaliItem(mt);
            return ApiResponse(true, "MenuThaliItems are Added", mt);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuThaliItem(UpdateMenuthaliItem mt)
        {
            await _menuThaliItemService.UpdatMenuThaliItem(mt);
            return ApiResponse(true, "MenuThaliItem are Added", mt);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _menuThaliItemService.DeleteMenuThaliItem(id);
            return ApiResponse(true, "MenuThaliItem are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMenuThaliItembyId(int id)
        {
            var data = await _menuThaliItemService.GetMenuThaliItemById(id);
            if (data == null)
                return ApiResponse(false, "MenuThaliItem not found");

            return ApiResponse(true, "MenuThaliItem fetched successfully", data);
        }

    }
}
