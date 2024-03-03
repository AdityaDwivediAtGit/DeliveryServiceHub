using Azure.Core;
using DeliveryService.Data.DataAccess;
using DeliveryService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repository
{
    public class RequestRepository: IRequestRepository
    {
        private readonly ISQLDataAccess _dataAccess;

        public RequestRepository(ISQLDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<IEnumerable<DeliveryRequest>> GetAllRequests()
        {
            return await _dataAccess.GetData<DeliveryRequest, object>("GetAllDeliveryRequests", null);
        }
        public async Task<DeliveryRequest> GetRequestById(int requestId)
        {
            var requests = await _dataAccess.GetData<DeliveryRequest, int>("GetDeliveryRequestById", requestId);
            return requests.FirstOrDefault();
        }

        public async Task<int> InsertRequest(DeliveryRequest request)
        {
            var result = await _dataAccess.GetData<int, object>("InsertDeliveryRequest", new
            {
                ShopId = request.ShopId,
                Items = request.Items,
                DeliveryPartner = request.DeliveryPartner
            });
            return (int)result.FirstOrDefault();
        }

        public async Task UpdateRequest(DeliveryRequest request)
        {
            await _dataAccess.SaveData("UpdateDeliveryRequest", request);
        }

        public async Task DeleteRequest(int requestId)
        {
            await _dataAccess.SaveData("DeleteDeliveryRequest", new { RequestId = requestId });
        }

        //public async Task<int> LastSavedRequest()
        //{
        //    var result = await _dataAccess.GetData<int, object>("LastSavedRequest", new int { });
        //    return result.FirstOrDefault();
        //}
    }
}
