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
    public class ResponseRepository: IResponseRepository
    {
        private readonly ISQLDataAccess _dataAccess;

        public ResponseRepository(ISQLDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<DeliveryResponse>> GetAllResponses()
        {
            return await _dataAccess.GetData<DeliveryResponse, object>("GetAllDeliveryResponses", null);
        }

        public async Task<DeliveryResponse> GetResponseById(int responseId)
        {
            var response = await _dataAccess.GetData<DeliveryResponse, int>("GetDeliveryResponseById", responseId);
            return response.FirstOrDefault();
        }

        public async Task InsertResponse(DeliveryResponse response)
        {
            // Method 1: giving SQLDateTimeOverflow
            //await _dataAccess.SaveData("InsertDeliveryResponse", new DeliveryResponse()
            //{
            //    RequestId = request.RequestId,
            //    Provider = request.DeliveryPartner,
            //    Response = response.ToString()
            //});

            // Mehod2: fixed date time overflow
            //response.ResponseDate = DateTime.Now;
            //await _dataAccess.SaveData("InsertDeliveryResponse", response);

            await _dataAccess.SaveData("InsertDeliveryResponse", new
            {
                RequestId = response.RequestId,
                Provider = response.Provider,
                Response = response.Response,
                ResponseDate = DateTime.Now
            });
        }

        public async Task UpdateResponse(DeliveryResponse response)
        {
            await _dataAccess.SaveData("UpdateDeliveryResponse", response);
        }

        public async Task DeleteResponse(int responseId)
        {
            await _dataAccess.SaveData("DeleteDeliveryResponse", new { ResponseId = responseId });
        }
    }
}
