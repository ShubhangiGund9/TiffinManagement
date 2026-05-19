using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : BaseApiController
    {
        ICustomerService _customerService;

        public CustomerApiController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<TblCustomer>> GetCategory()
        {
            var lst = await _customerService.GetAllCustomer();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateDtoCustomer c)
        {
            await _customerService.AddCustomer(c);
            return ApiResponse(true, "Customer are Added", c);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateDtoCustomer c)
        {
            await _customerService.UpdateCustomer(c);
            return ApiResponse(true, "Customer are updated", c);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);
            return ApiResponse(true, "Customer are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomerbyId(int id)
        {
            var data = await _customerService.GetCustomerById(id);
            if (data == null)
                return ApiResponse(false, "Customer not found");

            return ApiResponse(true, "Customer fetched successfully", data);
        }



    }
}
