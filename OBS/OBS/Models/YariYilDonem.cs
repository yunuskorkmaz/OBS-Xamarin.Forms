using Newtonsoft.Json;

namespace OBS.Models
{
    public class YariYilDonem
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("adi")]
        public string Adi { get; set; }
    }
}
