using Microsoft.AspNetCore.Mvc;
using Project_Model.Models;
using Project_Service.Services.Interface;

namespace OnlineTiffinSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CustomerController : Controller
    {

        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _customerService.GetAllCustomer();
            return View(data);
        }



    }
}
