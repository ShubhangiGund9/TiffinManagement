using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Implemenation;
using Project_Service.Services.Interface;

namespace Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryChargesApiController : BaseApiController
    {

        IDeliveryChargesService _deliveryChargesService;
        public DeliveryChargesApiController(IDeliveryChargesService deliveryChargesService)
        {
            _deliveryChargesService = deliveryChargesService;
        }

        [HttpGet]
        public async Task<List<TblDeliveryCharges>> GetDeliveryCharge()
        {
            var lst = await _deliveryChargesService.GetAllDeliveryCharges();
            return lst;
        }

        [HttpPost]
        public async Task<IActionResult> AddDeliveryCharges(CreateDeliveryCharges d)
        {
            await _deliveryChargesService.AddDeliveryCharges(d);
            return ApiResponse(true, "DeliveryChargesare Added", d);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeliveryCharges(UpdateDeliveryCharges dc)
        {
            await _deliveryChargesService.UpdateDeliveryCharges(dc);
            return ApiResponse(true, "DeliveryCharges updated", dc);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDeliveryCharges(int id)
        {
            await _deliveryChargesService.DeleteDeliveryCharges(id);
            return ApiResponse(true, "DeliveryCharges are deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDeliveryChargesbyId(int id)
        {
            var data = await _deliveryChargesService.GetDeliveryChargesById(id);
            if (data == null)
                return ApiResponse(false, "DeliveryCharges not found");

            return ApiResponse(true, "DeliveryCharges fetched successfully", data);
        }

    }
}
