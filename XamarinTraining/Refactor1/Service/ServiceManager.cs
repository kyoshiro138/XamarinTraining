using Newtonsoft.Json;
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
        public ServiceManager(ILoadingDialog loading, INetworkDetector network) : base(loading, network)
        {
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

    public class IOSLoadingImpl : ILoadingDialog
    {
        public void HideLoadingProgress() { Console.WriteLine("IOS Hide loading"); }
        public void ShowLoadingProgress() { Console.WriteLine("IOS Show loading"); }
    }

    public class DroidLoadingImpl : ILoadingDialog
    {
        public void HideLoadingProgress() { Console.WriteLine("Android Hide loading"); }
        public void ShowLoadingProgress() { Console.WriteLine("Android Show loading"); }
    }

    public class DroidNetworkDetector : INetworkDetector
    {
        public bool HasNetworkConnection() { return true; }
    }

    public class IOSNetworkDetector : INetworkDetector
    {
        public bool HasNetworkConnection() { return true; }
    }
}
