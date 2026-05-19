using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessDetailApiController : BaseApiController
    {
        IMessDetailService _messDetailService;
        public MessDetailApiController(IMessDetailService messDetailService)
        {
            _messDetailService = messDetailService;
        }


        [HttpGet]
        // [Route("api/MessDetailApi")]
        public async Task<List<TblMessDetail>> GetMessDetail()
        {
            var lst = await _messDetailService.GetAllMessDetails();
            return lst;
         }

        [HttpPost]
        // [Route("api/MessDetailApi")]
        public async Task<IActionResult> AddMessDetail(CreateDtoMessDetail tm)
        {
            await _messDetailService.AddMessDetail(tm);
            return ApiResponse(true, "MessDetails are Added",tm);
        }

        [HttpPut]
        //[Route("api/MessDetailApi")]
        public async Task<IActionResult> UpdateMessDetail(UpdateDtoMessDetail tm)
        {
            await _messDetailService.UpdateMessDetail(tm);
            return ApiResponse(true, "MessDetails are updated",tm);
        }

        [HttpDelete]
        //[Route("api/MessDetailApi")]
        public async Task<IActionResult> DeleteMessDetail(int id)
        {
            await _messDetailService.DeleteMessDetail(id);
            return ApiResponse(true, "MessDetail are deleted");
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetMessDetailById(int id)
        {
            var data = await _messDetailService.GetMessDetailById(id);
            if (data == null)
                return ApiResponse(false, "MessDetail not found");

            return ApiResponse(true, "MessDetail fetched successfully", data);
        }
            
        }


    }

