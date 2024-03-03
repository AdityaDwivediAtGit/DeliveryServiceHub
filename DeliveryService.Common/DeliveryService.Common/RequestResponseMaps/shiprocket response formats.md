Common api response format
{
  "status": "success",
  "deliveryResponses":{
    "provider": "ShipRocket",
    "response": {
      "status": "success",
      "trackingId": "SR-123456"
    }
  }
}

Common api response model
    public class DeliveryResponse
    {
        public int ResponseId { get; set; }

        [Required]
        public int RequestId { get; set; }
        public string? Provider { get; set; }
        public string? Response { get; set; }
        public DateTime ResponseDate { get; set; }
    }

Shiprocket response format
{
  "status": "success",
  "trackingId": "SR-987654"
}