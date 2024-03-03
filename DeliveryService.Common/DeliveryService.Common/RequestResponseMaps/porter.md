b. Porter API Example:

Request:
{
  "order_id": "123456",
  "product_ids": ["789"],
  "quantity": 2,
  "address": "123 Main St, Anytown, AA 12345"
}
Response:
{
  "status": "success",
  "booking_id": "PRT-987654"
}


CommonAPI Request Example:
{
  "shopId": 123,
  "items": [
      "item1", "item2"
  ],
  "deliveryPartners": "ShipRocket"
}

CommonAPI Request Model:
    public class DeliveryRequest
    {
        public int RequestId { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        public string Items { get; set; }

        [Required]
        public string DeliveryPartner { get; set; }
        public DateTime RequestDate { get; set; }

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