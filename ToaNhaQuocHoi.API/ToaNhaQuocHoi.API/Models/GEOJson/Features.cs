using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToaNhaQuocHoi.API.Models.GEOJson
{
    public class Features
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        public geometry geometry { get; set; }
        public properties properties { get; set; }
    }
}
