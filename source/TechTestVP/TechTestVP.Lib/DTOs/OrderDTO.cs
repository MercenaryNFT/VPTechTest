using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.Models;

namespace TechTestVP.Lib.DTOs
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
