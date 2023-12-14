using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TechTestVPEF.Lib.DTO
{
    public class OrderLineDTO
    {
        [JsonProperty("productId"), Required]
        public string ProductId { get; set; }
        [JsonProperty("quantity"), Required]
        public int Quantity { get; set; }
        [JsonProperty("uom"), Required]
        public string UnitOfMeasure { get; set; }
    }
}
