namespace DeliveryService.Porter.Models
{
    public class PorterOrderRequest
    {
            public string order_id { get; set; }
            public List<string> products { get; set; }
            public int quantity { get; set; }
            public string address { get; set; }

    }
}
