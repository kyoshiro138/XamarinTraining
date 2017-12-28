using Newtonsoft.Json;
using Refactor1.Model;
using Refactor1.Service.Request;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Service
{
    public abstract class BaseServiceManager : IServiceManager
    {
        protected virtual string BaseUrl => "https://ft-ductuu138.oraclecloud2.dreamfactory.com/";

        private HttpClient _client;

        public BaseServiceManager()
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var url = BaseUrl + "api/v2/user/session";
            var request = new AuthenticationRequest() { Email = email, Password = password };
            var response = await InvokeService(HttpMethod.Post, url, request);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseBody);
                return user;
            }
            else
            {
                return null;
            }
        }

        private async Task<HttpResponseMessage> InvokeService(HttpMethod method, string url, object bodyObject = null)
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
