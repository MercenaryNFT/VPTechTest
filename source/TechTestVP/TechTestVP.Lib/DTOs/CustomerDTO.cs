using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestVP.Lib.DTOs
{

    public class CustomerDTO
    {
        [JsonProperty("id"), Required]
        public string Id { get; set; }
    }
}
