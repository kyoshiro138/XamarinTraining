using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor2.Model;
using Refactor2.Service.Request;
using System.Net.Http;
using Newtonsoft.Json;
using Refactor2.Service.Response;

namespace Refactor2.Service
{
    public class ApplicationServiceManager : BaseServiceManager, IServiceManager
    {
        private string AuthenticateUrl = "api/v2/user/session";
        private string NewsUrl = "api/v2/db/_table/news";

        public ApplicationServiceManager(string baseUrl, ILoadingProgressor loadingProgressor, INetworkDetector networkDetector) 
            : base(baseUrl, loadingProgressor, networkDetector)
        {
            Client.DefaultRequestHeaders.Add("X-DreamFactory-Api-Key", "36fda24fe5588fa4285ac6c6c2fdfbdb6b6bc9834699774c9bf777f706d05a88");
        }

        public async Task<User> Authenticate(AuthenticationRequest request)
        {
            var response = await InvokeService(HttpMethod.Post, AuthenticateUrl, request);
            if (response.IsSuccessStatusCode)
            {
                return await DeserializeUser(response.Content);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<News>> GetNews()
        {
            var response = await InvokeService(HttpMethod.Get, NewsUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await DeserializeNews(response.Content);
                return responseData != null ? responseData.NewsList : null;
            }
            else
            {
                return null;
            }
        }

        public void SaveToken(string token)
        {
            Client.DefaultRequestHeaders.Add("X-DreamFactory-Session-Token", token);
        }

        private async Task<User> DeserializeUser(HttpContent content)
        {
            var responseBody = await content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseBody);
            return user;
        }

        private async Task<NewsResponse> DeserializeNews(HttpContent content)
        {
            var responseBody = await content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<NewsResponse>(responseBody);
            return response;
        }
    }
}
