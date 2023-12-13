using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.Enums;

namespace TechTestVP.Lib.DTOs
{
    public class OrderLineDTO
    {
        [JsonProperty("productId"), Required]
        public int ProductId { get; set; }
        [JsonProperty("quantity"), Required]
        public int Quantity { get; set; }
        [JsonProperty("uom"), Required]
        public UOM UnitOfMeasure { get; set; }
    }
}
