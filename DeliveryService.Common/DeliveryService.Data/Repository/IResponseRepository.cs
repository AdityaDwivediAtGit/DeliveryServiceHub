using DeliveryService.Data.DataAccess;
using DeliveryService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repository
{
    public interface IResponseRepository
    {
        Task<IEnumerable<DeliveryResponse>> GetAllResponses();

        Task<DeliveryResponse> GetResponseById(int responseId);

        Task InsertResponse(DeliveryResponse response);

        Task UpdateResponse(DeliveryResponse response);

        Task DeleteResponse(int responseId);
    }
}
