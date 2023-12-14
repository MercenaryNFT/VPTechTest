using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TechTestVPEF.Lib.DTO
{
    public class CustomerDTO
    {
        [JsonProperty("id"), Required]
        public string Id { get; set; }
    }
}
