using DeliveryService.Data.Models;
using DeliveryService.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using DeliveryService.Common.RequestResponseMaps;
using DeliveryService.Common.RequestSenders;
using DeliveryService.Common.Delivery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryService.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        #region Depndency injection
        private readonly IRequestRepository _requestRepository;
        private readonly IResponseRepository _responseRepository;
        private readonly IDeliver _deliver;
        //private readonly IConfiguration _config;

        //public DeliveryController(IRequestRepository requestRepository, IResponseRepository responseRepository, IConfiguration config)
        public DeliveryController(IRequestRepository requestRepository, IResponseRepository responseRepository, IDeliver deliver)
        {
            _requestRepository = requestRepository;
            _responseRepository = responseRepository;
            //_config = config;
            _deliver = deliver;
        }
        #endregion

        //var localhost_ip = Environment.GetEnvironmentVariable("localhost_ip");

        [HttpPost]
        public async Task<IActionResult> DeliverProduct(DeliveryRequest request)
        {
            try
            {
                // User should not be allowed to alter time
                request.RequestDate = DateTime.Now;

                #region Save request to database + fetch request id
                //await _requestRepository.InsertRequest(request);
                //request.RequestId = await _requestRepository.LastSavedRequest();

                request.RequestId = await _requestRepository.InsertRequest(request);

                #endregion

                #region send request and recieve response

                //object partnerRequest;
                //object partnerResponse;
                //DeliveryResponse commonApiResponse;
                //IMapper ShipRocketMapper_obj = new ShipRocketMapper();
                //IMapper porter_mapper_obj = new PorterMapper();

                //switch (request.DeliveryPartner.ToLower())
                //{
                //    case "shiprocket":
                //        // Map request to chosen delivery partner API format
                //        partnerRequest = ShipRocketMapper_obj.ConvertRequestToPartner(request);

                //        // Send request to ShipRocket API (simulated here)
                //        //var shipRocketRequester = new ShipRocketRequester();
                //        //var shipRocketResponse = await ShipRocketRequester().SendToShipRocket(shipRocketRequest);
                //        //partnerResponse = await Requester.Send(partnerRequest, $"http://192.168.68.171:8007/api/Orders");
                //        partnerResponse = await Requester.Send(partnerRequest, _config["DeliveryPartnerUrls:ShipRocket"]);

                //        // Map ShipRocket response to common API response format
                //        //var commonApiResponse = MappingService.MapToCommonApiResponse(shipRocketResponse, request);
                //        commonApiResponse = ShipRocketMapper_obj.ConvertResponseToCommonApi(partnerResponse, request);
                //        break;

                //        case "porter":
                //        //partnerRequest = PorterMapper.ConvertRequestToPartner(request);
                //        partnerRequest = porter_mapper_obj.ConvertRequestToPartner(request);
                //        //partnerResponse = await Requester.Send(partnerRequest, "http://localhost:8004/api/Products");
                //        partnerResponse = await Requester.Send(partnerRequest, _config["DeliveryPartnerUrls:Porter"]);
                //        commonApiResponse = porter_mapper_obj.ConvertResponseToCommonApi(partnerResponse, request);
                //        break;

                //    default:
                //        return BadRequest($"Provider '{request.DeliveryPartner}' not supported.");
                //}

                /////////////////////////////////////////////////////////////////////


                #endregion


                #region new send request and recieve response (Incomplete)

                // Send request and receive response
                var commonApiResponse = await _deliver.ConvertAndSend(request);

                #endregion

                #region Save response to database
                // Save response to database
                await _responseRepository.InsertResponse(commonApiResponse);
            #endregion

                // Return response to store owner
                return Ok(commonApiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error occured at CommonAPI: {ex.Message}");
            }
        }
    }
}
