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


ShipRocket API Request example:
{
  "orderId": "123456",
  "items": [
    "item1", "item2"
  ],
  "deliveryAddress": {
    "street": "123 Main St",
    "city": "Anytown",
    "state": "AA",
    "zip": "12345"
  }
}