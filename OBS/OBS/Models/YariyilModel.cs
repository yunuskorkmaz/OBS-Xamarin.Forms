using Newtonsoft.Json;
using System.Collections.Generic;

namespace OBS.Models
{
    public class YariyilModel
    {
        [JsonProperty("son_yariYil_id")]
        public string SonYariYil { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("sonuclar")]
        public List<YariYilDonem> YariYillar { get; set; }
    }
}
