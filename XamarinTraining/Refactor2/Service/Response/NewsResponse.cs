using Newtonsoft.Json;
using Refactor2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service.Response
{
    public class NewsResponse
    {
        [JsonProperty("resource")]
        public List<News> NewsList { get; set; }
    }
}
