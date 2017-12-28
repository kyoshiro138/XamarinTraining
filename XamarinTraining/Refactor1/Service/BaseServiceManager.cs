using Newtonsoft.Json;
using Refactor1.Service.Request;
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
        protected string BaseUrl => "https://ft-ductuu138.oraclecloud2.dreamfactory.com/";

        private HttpClient _client;
        private ILoadingDialog _loading;
        private INetworkDetector _networkDetector;

        public BaseServiceManager(ILoadingDialog loading, INetworkDetector networkDetector)
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
            _loading = loading;
            _networkDetector = networkDetector;
        }

        public async Task<HttpResponseMessage> InvokeService(HttpMethod method, string url, object bodyObject = null)
        {
            if (_networkDetector.HasNetworkConnection())
            {
                _loading.ShowLoadingProgress();
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
                _loading.HideLoadingProgress();
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
