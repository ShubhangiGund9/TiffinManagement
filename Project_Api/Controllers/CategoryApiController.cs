using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : BaseApiController
    {

        ICategoryService _categoryService;
        public CategoryApiController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<TblCategory>> GetCategory()
        {
            var lst = await _categoryService.GetCategories();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateDtoCategory c)
        {
            await _categoryService.AddCategories(c);
            return ApiResponse(true, "Category are Added", c);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateDtoCategory c)
        {
            await _categoryService.UpdateCategories(c);
            return ApiResponse(true, "Category are updated", c);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategories(id);
            return ApiResponse(true, "Category are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategorybyId(int id)
        {
            var data = await _categoryService.GetCategoryById(id);
            if (data == null)
                return ApiResponse(false, "Category not found");

            return ApiResponse(true, "Category fetched successfully", data);
        }


    }
}
