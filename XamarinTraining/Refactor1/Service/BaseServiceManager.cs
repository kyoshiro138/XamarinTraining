using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Service
{
    public abstract class BaseServiceManager
    {
        protected string BaseUrl { get { return "https://ft-ductuu138.oraclecloud2.dreamfactory.com/"; } }

        private HttpClient _client;

        public BaseServiceManager()
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
        }

        public async Task<HttpResponseMessage> InvokeService(HttpMethod method, string ContentUrl, object bodyObject = null)
        {
            if (HasNetworkConnection())
            {
                ShowLoadingProgress();
                HttpResponseMessage responseMessage = null;
                try
                {
                    var requestMessage = new HttpRequestMessage(method, BaseUrl + ContentUrl);
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
