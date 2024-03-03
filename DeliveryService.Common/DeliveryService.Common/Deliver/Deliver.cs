using DeliveryService.Common.Delivery;
using DeliveryService.Common.RequestResponseMaps;
using DeliveryService.Common.RequestSenders;
using DeliveryService.Data.Models;

namespace DeliveryService.Common.Deliver
{
    public class Deliver:IDeliver
    {
        //partnerRequest = porter_mapper_obj.ConvertRequestToPartner(request);           
        //partnerResponse = await Requester.Send(partnerRequest, _config["DeliveryPartnerUrls:Porter"]);
        //commonApiResponse = porter_mapper_obj.ConvertResponseToCommonApi(partnerResponse, request);

        private readonly IConfiguration _config;
        private readonly IMapper _delivery_mapper_obj;

        public Deliver(IConfiguration config, IMapper delivery_mapper_obj)
        {
            _config = config;
            _delivery_mapper_obj = delivery_mapper_obj;
        }

        public async Task<DeliveryResponse> ConvertAndSend(DeliveryRequest request)
        {
            object partnerRequest = _delivery_mapper_obj.ConvertRequestToPartner(request);
            object partnerResponse = await Requester.Send(partnerRequest, _config[$"DeliveryPartnerUrls:{request.DeliveryPartner.ToLower()}"]);
            DeliveryResponse commonApiResponse = _delivery_mapper_obj.ConvertResponseToCommonApi(partnerResponse, request);

            return commonApiResponse;
        }

    }
}
