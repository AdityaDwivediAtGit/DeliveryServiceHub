using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace DeliveryService.Common.RequestSenders
{
    public class Requester
    {
        //private readonly IConfiguration _config;
        //public ShipRocketRequester(IConfiguration config) { _config = config; }
        public static async Task<object> Send(object shipRocketRequest, string apiUrl)
        {
            using HttpClient client = new HttpClient();

            // Serialize the shipRocketRequest object to JSON
            string jsonRequest = JsonConvert.SerializeObject(shipRocketRequest);

            // Create a StringContent object with the JSON request
            StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // Send the POST request to the ShipRocket API URL
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response to an object and return it
                return JsonConvert.DeserializeObject(jsonResponse);
            }
            else
            {
                // Handle the unsuccessful response (e.g., throw an exception)
                throw new Exception($"Failed to send request [CommonApi]. Status code: {response.StatusCode}");
            }
        }
    }
}
