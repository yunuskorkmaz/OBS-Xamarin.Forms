using Newtonsoft.Json;

namespace OBS.Models
{
    public class Student
    {
        public int ID { get; set; }
        [JsonProperty("ogrenci_id")]
        public string Oibs_id { get; set; }
        [JsonProperty("oNo")]
        public string OgrenciNo { get; set; }
        [JsonProperty("adiSoyadi")]
        public string AdiSoyadi { get; set; }
        [JsonProperty("sinifi")]
        public string _sinifi { get; set; }
        [JsonProperty("fakulteAdi")]
        public string FakulteAdi { get; set; }
        [JsonProperty("programAdi")]
        public string ProgramAdi { get; set; }
        [JsonProperty("danismanAdi")]
        public string DanismanAdi { get; set; }
        [JsonProperty("success")]
        public int Success { get; set; }
        public string Sifre { get; set; }


        public string Sinifi { get { return _sinifi + ". Sınıf"; } }
    }
}
