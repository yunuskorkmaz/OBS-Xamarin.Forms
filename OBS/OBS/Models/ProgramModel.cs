using Newtonsoft.Json;

namespace OBS.Models
{
    public class ProgramModel
    {
        [JsonProperty("kodu")]
        public string Kodu { get; set; }
        [JsonProperty("dersAdi")]
        public string DersAdi { get; set; }
        [JsonProperty("ogretimElemaniAdi")]
        public string Hoca { get; set; }
        [JsonProperty("sinifi")]
        public string Sinifi { get; set; }
        [JsonProperty("derslikAdi")]
        public string Derslik { get; set; }
        [JsonProperty("saat")]
        public string Saat { get; set; }
        [JsonProperty("gun")]
        public string Gun { get; set; }
    }
}
