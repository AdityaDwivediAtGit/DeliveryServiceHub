using DeliveryService.Data.Models;

namespace DeliveryService.Common.RequestResponseMaps
{
    public class PorterMapper : IMapper
    //public class PorterMapper
    {
        public object ConvertRequestToPartner(DeliveryRequest request)
        {
            return new
            {
                order_id = request.RequestId.ToString() +"_"+ request.ShopId.ToString() + "_OrderReceivedByCommonAPI",
                products = request.Items.Split(", "),
                quantity = 1,
                address = "123 Main St, Anytown, AA 12345"
            };
        }

        public DeliveryResponse ConvertResponseToCommonApi(object porterResponse, DeliveryRequest request)
        {
            dynamic porter = porterResponse;

            DeliveryResponse commonApiResponse = new DeliveryResponse()
            {
                RequestId = request.RequestId,
                Provider = request.DeliveryPartner,
                Response = porterResponse.ToString(),
                ResponseDate = DateTime.UtcNow
            };

            return commonApiResponse;
        }
    }
}
