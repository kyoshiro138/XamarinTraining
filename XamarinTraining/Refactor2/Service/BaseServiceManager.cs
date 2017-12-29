using Newtonsoft.Json;
using Refactor2.Service.Interface;
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
        protected abstract string BaseUrl { get; }

        private HttpClient _client;
        private ILoadingProgressor _loadingProgressor;
        private INetworkDetector _networkDetector;
        private IParser _parser;

        protected HttpClient Client { get { return _client; } }

        public BaseServiceManager(ILoadingProgressor loadingProgressor, INetworkDetector networkDetector, IParser parser)
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
            _loadingProgressor = loadingProgressor;
            _networkDetector = networkDetector;
            _parser = parser;
        }

        public async Task<HttpResponseMessage> InvokeService(HttpMethod method, string methodUrl, object bodyObject = null)
        {
            if (_networkDetector.HasNetworkConnection)
            {
                _loadingProgressor.ShowLoadingProgress();
                HttpResponseMessage responseMessage = null;
                try
                {
                    var requestMessage = new HttpRequestMessage(method, BaseUrl + methodUrl);
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

        protected async Task<T> Deserialize<T>(HttpContent content)
        {
            var responseBody = await content.ReadAsStringAsync();
            var responseObject = _parser.DeserializeObject<T>(responseBody);
            return responseObject;
        }

        private HttpContent CreateRequestBodyContent(object bodyObject)
        {
            var bodyString = _parser.SerializeObject(bodyObject);
            return new StringContent(bodyString, Encoding.UTF8, "application/json");
        }
    }
}
