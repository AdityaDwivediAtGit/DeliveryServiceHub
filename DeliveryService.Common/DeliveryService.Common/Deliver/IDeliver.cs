using DeliveryService.Data.Models;

namespace DeliveryService.Common.Delivery
{
    public interface IDeliver
    {
        Task<DeliveryResponse> ConvertAndSend(DeliveryRequest request);
    }
}
