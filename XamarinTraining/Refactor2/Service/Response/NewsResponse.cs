using Newtonsoft.Json;
using Refactor2.Model;
using System.Collections.Generic;

namespace Refactor2.Service.Response
{
    public class NewsResponse
    {
        [JsonProperty("resource")]
        public List<News> NewsList { get; set; }
    }
}
