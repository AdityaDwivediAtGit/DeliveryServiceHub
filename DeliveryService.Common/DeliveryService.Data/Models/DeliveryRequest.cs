using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Models
{
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
    }
}
