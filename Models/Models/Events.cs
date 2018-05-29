namespace Models.Models
{
    using System;
    using Newtonsoft.Json;

    public class Events
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "event_date")]
        public DateTime EventDate { get; set; }

        [JsonProperty(PropertyName = "base_title")]
        public string BaseTitle { get; set; }

        [JsonProperty(PropertyName = "title_tag_line")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "arena")]
        public string Arena { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
    }
}
