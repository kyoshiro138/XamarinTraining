using Newtonsoft.Json;
using Refactor1.Helper;
using Refactor1.Model;
using Refactor1.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Service
{
    public class ServiceManager : BaseServiceManager, IServiceManager
    {
        protected override string BaseUrl => "https://ft-ductuu138.oraclecloud2.dreamfactory.com/";

        private IHelper _helper;
        public override IHelper Helper => _helper;

        public ServiceManager (IHelper helper)
        {
            _helper = helper;
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
    }
}
