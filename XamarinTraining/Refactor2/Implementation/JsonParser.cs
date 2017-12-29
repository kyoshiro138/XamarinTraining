using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refactor2.Service;

namespace Refactor2.Implementation
{
    public class JsonParser : IParser
    {
        public async Task<T> DeserializeObject<T>(HttpContent content)
        {
            var responseBody = await content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<T>(responseBody);
            return response;
        }

        public HttpContent CreateRequestBodyContent(object bodyObject)
        {
            var bodyString = JsonConvert.SerializeObject(bodyObject);
            return new StringContent(bodyString, Encoding.UTF8, "application/json");
        }
    }
}
