using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Models
{
    public class DeliveryResponse
    {
        public int ResponseId { get; set; }

        [Required]
        public int RequestId { get; set; }
        public string? Provider { get; set; }
        public string? Response { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
