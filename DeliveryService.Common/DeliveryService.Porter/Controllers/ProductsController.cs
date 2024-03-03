using DeliveryService.Porter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Porter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        //public async Task<IActionResult> BookDelivery([FromBody] PorterOrderRequest request)
        public async Task<IActionResult> BookDelivery([FromBody] PorterOrderRequest request)
        {
            //await Task.Delay(100); // Simulate delay
            var response = new
            {
                status = "success",
                booking_id = $"PRT-{new Random().Next(100000, 999999)}-{request.order_id}" // Simulated booking ID
            };

            return Ok(response);
        }
}
}
