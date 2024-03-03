using DeliveryService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repository
{
    public interface IRequestRepository
    {
        Task<IEnumerable<DeliveryRequest>> GetAllRequests();
        Task<DeliveryRequest> GetRequestById(int requestId);
        Task<int> InsertRequest(DeliveryRequest request);
        Task UpdateRequest(DeliveryRequest request);
        Task DeleteRequest(int requestId);
        //Task<int> LastSavedRequest();
    }
}
