using System.Collections.Generic;
using Newtonsoft.Json;

namespace GojimoChallenge.Contracts.Dto
{
    public class QualificationDto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "subjects")]
        public List<SubjectDto> Subjects { get; set; }

 

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}