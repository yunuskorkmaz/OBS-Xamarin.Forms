using Newtonsoft.Json;

namespace OBS.Models
{
    public class BasariTakipModel
    {
        [JsonProperty("grupAdi")]
        public string GrupAdi { get; set; }
        [JsonProperty("adi")]
        public string DersAdi { get; set; }
        [JsonProperty("kredi")]
        public string Kredi { get; set; }
        [JsonProperty("puan")]
        public string Puan { get; set; }
        [JsonProperty("sonuc")]
        public string Sonuc { get; set; }
        [JsonProperty("durum")]
        public string Durum { get; set; }


        public string PuanSonuc
        {
            get
            {
                if (Sonuc == "S")
                    return Puan;
                else
                    return Puan + " - " + Sonuc;
            }
        }

        public Xamarin.Forms.Color DurumRenk
        {
            get
            {
                if (Durum == "Başarısız")
                    return Xamarin.Forms.Color.Red;
                else if (Durum == "Başarılı")
                    return Xamarin.Forms.Color.Green;
                else
                    return Xamarin.Forms.Color.FromHex("#283593");

            }
        }
    }
}
