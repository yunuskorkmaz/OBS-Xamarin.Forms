using Newtonsoft.Json;

namespace OBS.Models
{
    public class OrtalamaItem
    {
        [JsonProperty("adi")]
        public string Adi { get; set; }
        [JsonProperty("dno")]
        public string DNO { get; set; }
        [JsonProperty("gno")]
        public string GNO { get; set; }
    }
}
