using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Service
{
    public abstract class BaseServiceManager
    {
        protected abstract string BaseUrl { get; }

        private HttpClient _client;

        public BaseServiceManager()
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
        }

        public async Task<HttpResponseMessage> InvokeService(HttpMethod method, string url, object bodyObject = null)
        {
            if (HasNetworkConnection())
            {
                ShowLoadingProgress();
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
                HideLoadingProgress();
                return responseMessage;
            }
            else
            {
                Console.WriteLine("No network connection.");
                return null;
            }
        }

        protected abstract void ShowLoadingProgress();

        protected abstract void HideLoadingProgress();

        protected abstract bool HasNetworkConnection();
    }
}
