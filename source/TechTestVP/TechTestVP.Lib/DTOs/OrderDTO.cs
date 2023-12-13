using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.Models;

namespace TechTestVP.Lib.DTOs
{
    public class OrderDTO
    {
        [JsonProperty("reference")]
        public string CustomerRef { get; set; }
        [JsonProperty("customer")]
        public CustomerDTO Customer { get; set; }
        [JsonProperty("lines")]
        public List<OrderLineDTO> Lines { get; set; }
        [JsonProperty("requiredDate")]
        public DateTime? RequiredDate { get; set; }
    }
}
