using Newtonsoft.Json;

namespace OBS.Models
{
    public class Sinav
    {
        [JsonProperty("adi")]
        public string Adi { get; set; }
        [JsonProperty("not")]
        public string Not { get; set; }
        [JsonProperty("sinifOrtalamasi")]
        public string Ortalama { get; set; }
    }
}
