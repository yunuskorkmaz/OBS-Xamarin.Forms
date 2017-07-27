using Newtonsoft.Json;
using System.Collections.Generic;

namespace OBS.Models
{
    public class OrtalamaModel
    {
        [JsonProperty("sno")]
        public List<OrtalamaItem> SNO { get; set; }
        [JsonProperty("dno")]
        public List<OrtalamaItem> DNO { get; set; }
    }
}
