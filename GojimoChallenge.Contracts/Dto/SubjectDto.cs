using Newtonsoft.Json;

namespace GojimoChallenge.Contracts.Dto
{
    public class SubjectDto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "colour")]
        public string Colour { get; set; }
    }
}