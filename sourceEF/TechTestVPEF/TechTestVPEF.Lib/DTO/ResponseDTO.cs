using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace TechTestVPEF.Lib.DTO
{
    public class ReponseDTO
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("Errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidationFailure> Errors { get; set; }
    }
}
