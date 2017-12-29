using GalaSoft.MvvmLight.Ioc;
using Refactor2.Model;
using Refactor2.Service;
using Refactor2.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Manager
{
    public class UserManager :BaseManager
    {
        public User CurrentUser { get; private set; }

        public UserManager(IServiceManager _serviceManager) : base(_serviceManager)
        {         
        }

        private async Task<User> Authenticate(string email,string password)
        {
            var request = new AuthenticationRequest()
            {
                Email = email,
                Password = password
            };
            return await ServiceManager.Authenticate(request);
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await Authenticate(email, password);
            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveToken()
        {
            ServiceManager.SaveToken(CurrentUser.Token);
        }
    }
}
