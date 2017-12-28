using Newtonsoft.Json;
using Refactor1.Helper;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Service
{
    public abstract class BaseServiceManager
    {
        protected abstract string BaseUrl { get; }
        public abstract IHelper Helper { get; }

        private HttpClient _client;

        public BaseServiceManager()
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
        }

        public async Task<HttpResponseMessage> InvokeService(HttpMethod method, string url, object bodyObject = null)
        {
            if (Helper.HasNetworkConnection())
            {
                Helper.ShowLoadingProgress();
                HttpResponseMessage responseMessage = null;
                try
                {
                    var requestMessage = new HttpRequestMessage(method, url);
                    if (bodyObject != null)
                    {
                        var bodyString = JsonConvert.SerializeObject(bodyObject);
                        requestMessage.Content = new StringContent(bodyString, Encoding.UTF8, "application/json");
                    }
                    responseMessage = await _client.SendAsync(requestMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Helper.HideLoadingProgress();
                return responseMessage;
            }
            else
            {
                Console.WriteLine("No network connection.");
                return null;
            }
        }
    }
}
