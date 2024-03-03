using DeliveryService.Data.Models;

namespace DeliveryService.Common.RequestResponseMaps
{
    public class ShipRocketMapper : IMapper
    //public class ShipRocketMapper
    {
        #region ShipRocket
        public object ConvertRequestToPartner(DeliveryRequest request)
        {
            // Map DeliveryRequest to ShipRocket API format
            return new
            {
                orderId = request.ShopId.ToString()+"_OrderReceivedByCommonAPI",
                items = request.Items.Split(", "), // Split items string into array
                deliveryAddress = new
                {
                    street = "123 Main St",
                    city = "Anytown", 
                    state = "AA", 
                    zip = "12345"
                }
            };
        }

        public DeliveryResponse ConvertResponseToCommonApi(object shipRocketResponse, DeliveryRequest deliveryRequest)
        {
            // Converted the ShipRocket response to a dynamic object for easier manipulation
            dynamic shipRocket = shipRocketResponse;

            // Map the ShipRocket response to the common API response format
            //var commonApiResponse = new 
            //{
            //    status = "success",
            //    deliveryResponses = new
            //    {
            //        provider = "ShipRocket",
            //        response = new
            //        {
            //            status = shipRocket.status,
            //            trackingId = shipRocket.trackingId
            //        }
            //    }
            //};

            DeliveryResponse commonApiResponse = new DeliveryResponse() 
            {
                RequestId = deliveryRequest.RequestId,
                Provider = deliveryRequest.DeliveryPartner,
                Response = shipRocketResponse.ToString(),
                ResponseDate = DateTime.Now
            };

            return commonApiResponse;
        }

        #endregion
    }
}
