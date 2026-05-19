

using Microsoft.AspNetCore.Mvc;

namespace Project_Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult ApiResponse(
            bool success,
            string message,
            object data = null,
            int statusCode = 200
            )
        {
            var response = new
            {
                success,
                message,
                data               
            };

            return StatusCode(statusCode,response);
        }
    }
}
