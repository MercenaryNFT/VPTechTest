using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TechTestVPEF.Lib.DTO
{
    public class OrderDTO
    {
        [JsonProperty("reference"), Required]
        public string CustomerRef { get; set; }
        [JsonProperty("customer"), Required]
        public CustomerDTO Customer { get; set; }
        [JsonProperty("lines"), Required]
        public List<OrderLineDTO> Lines { get; set; }
        [JsonProperty("requiredDate"), Required]
        public DateTime? RequiredDate { get; set; }

    }
}
