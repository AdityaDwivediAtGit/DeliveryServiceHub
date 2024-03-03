using DeliveryService.Data.Models;

namespace DeliveryService.Common.RequestResponseMaps
{
    public interface IMapper
    {
        object ConvertRequestToPartner(DeliveryRequest request);
        DeliveryResponse ConvertResponseToCommonApi(object partnerResponse, DeliveryRequest request);
    }
}
