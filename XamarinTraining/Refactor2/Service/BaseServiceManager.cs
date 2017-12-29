using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service
{
    public abstract class BaseServiceManager
    {
        private string _baseUrl;
        private HttpClient _client;
        private ILoadingProgressor _loadingProgressor;
        private INetworkDetector _networkDetector;

        protected HttpClient Client { get { return _client; } }

        public BaseServiceManager(string baseUrl, ILoadingProgressor loadingProgressor, INetworkDetector networkDetector)
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
            _baseUrl = baseUrl;
            _loadingProgressor = loadingProgressor;
            _networkDetector = networkDetector;
        }

        public async Task<HttpResponseMessage> InvokeService(HttpMethod method, string methodUrl, object bodyObject = null)
        {
            if (_networkDetector.HasNetworkConnection)
            {
                _loadingProgressor.ShowLoadingProgress();
                HttpResponseMessage responseMessage = null;
                try
                {
                    var requestMessage = new HttpRequestMessage(method, _baseUrl + methodUrl);
                    if (bodyObject != null)
                    {
                        requestMessage.Content = CreateRequestBodyContent(bodyObject);
                    }
                    responseMessage = await _client.SendAsync(requestMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                _loadingProgressor.HideLoadingProgress();
                return responseMessage;
            }
            else
            {
                Console.WriteLine("No network connection.");
                return null;
            }
        }

        private HttpContent CreateRequestBodyContent(object bodyObject)
        {
            var bodyString = JsonConvert.SerializeObject(bodyObject);
            return new StringContent(bodyString, Encoding.UTF8, "application/json");
        }
    }
}
