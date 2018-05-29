namespace Models.Models
{
    using System;
    using Newtonsoft.Json;

    public class News
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "article_date")]
        public DateTime ArticleDate { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "thumbnail")]
        public string Image { get; set; }
    }
}
