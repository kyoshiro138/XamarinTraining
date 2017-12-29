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
        private ILoadingProgressor _loadingProgressor;
        private INetworkDetector _networkDetector;

        protected HttpClient Client { get; private set; }

        public BaseServiceManager(ILoadingProgressor loadingProgressor, INetworkDetector networkDetector)
        {
            Client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
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
                    var requestMessage = new HttpRequestMessage(method, BaseUrl + methodUrl);
                    if (bodyObject != null)
                    {
                        var requestContentFromJson = new RequestContentFromJson();
                        requestMessage.Content = requestContentFromJson.CreateRequestBodyContent(bodyObject);
                    }
                    responseMessage = await Client.SendAsync(requestMessage);
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
    }
}
