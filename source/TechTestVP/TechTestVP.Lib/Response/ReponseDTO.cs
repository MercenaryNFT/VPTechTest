using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.Models;

namespace TechTestVP.Lib.Response
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
