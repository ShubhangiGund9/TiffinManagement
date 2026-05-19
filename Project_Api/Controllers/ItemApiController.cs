using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemApiController : BaseApiController
    {
        IItemService _itemService;
        public ItemApiController(IItemService itemService)
        {
            _itemService = itemService;

        }
        [HttpGet]
        public async Task<List<ResponseItemDto>> GetAllItem()
        {
            var lst = await _itemService.GetAllItem();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(CreateDtoItem c)
        {
            await _itemService.AddItem(c);
            return ApiResponse(true, "Items are Added", c);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateDtoItem c)
        {
            await _itemService.UpdateItem(c);
            return ApiResponse(true, "Item are updated", c);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemService.DeleteItem(id);
            return ApiResponse(true, "Items are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetItembyId(int id)
        {
            var data = await _itemService.GetItemById(id);
            if (data == null)
                return ApiResponse(false,"Item not found");

            return ApiResponse(true, "Item fetched successfully", data);
        }



    }
}
