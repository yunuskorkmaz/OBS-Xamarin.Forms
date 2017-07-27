using Newtonsoft.Json;

namespace OBS.Models
{
    public class ResultData
    {
        [JsonProperty("Result")]
        public bool Result { get; set; }
        [JsonProperty("Data")]
        public T Data { get; set; }
        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
