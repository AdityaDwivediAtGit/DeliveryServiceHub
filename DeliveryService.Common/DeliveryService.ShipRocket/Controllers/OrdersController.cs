using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryService.ShipRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Random _random = new Random();

        [HttpPost]
        public IActionResult Deliver()
        {
            #region random response generation
            string status = _random.Next(2) == 0 ? "success" : "failure";
            string trackingId = "SR-" + _random.Next(100000, 999999);
            #endregion

            var response = new
            {
                status = status,
                trackingId = trackingId
            };

            return Ok(response);
        }
    }
}
