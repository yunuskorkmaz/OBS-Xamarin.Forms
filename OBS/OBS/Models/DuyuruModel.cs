using Newtonsoft.Json;

namespace OBS.Models
{
    public class DuyuruModel
    {
        [JsonProperty("baslik")]
        public string Baslik { get; set; }
        [JsonProperty("duyuruMetni")]
        public string Metin { get; set; }
        [JsonProperty("kullaniciAdi")]
        public string Kullanici { get; set; }
    }
}
