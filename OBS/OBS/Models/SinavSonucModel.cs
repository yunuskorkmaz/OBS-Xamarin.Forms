using Newtonsoft.Json;
using System;

namespace OBS.Models
{
    public class SinavSonucModel
    {
        [JsonProperty("kodu")]
        public string DersKodu { get; set; }
        [JsonProperty("tumuYayinda")]
        public int TumuYayinda { get; set; }
        [JsonProperty("ortalama")]
        public string Ortalama { get; set; }
        [JsonProperty("devamSartiText")]
        public string DevamSartiText { get; set; }
        [JsonProperty("devamSarti")]
        public int DevamSarti { get; set; }
        [JsonProperty("sonuc")]
        public string Sonuc { get; set; }
        [JsonProperty("adi")]
        public string DersAdi { get; set; }
        [JsonProperty("hoca")]
        public string Ogretmen { get; set; }
        [JsonProperty("vize")]
        public Sinav Vize { get; set; }
        [JsonProperty("final")]
        public Sinav Final { get; set; }
        [JsonProperty("Success")]
        public bool Success { get; set; } = false;

        public Color DevamSartRenk
        {
            get
            {
                if (DevamSarti == 1) return Color.Red;
                else return Color.Green;
            }
        }

        public Color SonucRenk
        {
            get
            {
                if (TumuYayinda == 0)
                {
                    return Color.Black;
                }
                else
                {
                    if (Convert.ToInt32(Ortalama) < 50)
                    {
                        return Color.Red;
                    }
                    else
                    {
                        return Color.Green;
                    }
                }

            }
            set { SonucRenk = value; }
        }
    }
}
