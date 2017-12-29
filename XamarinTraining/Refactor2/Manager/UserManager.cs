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
    public class UserManager
    {
        private readonly IServiceManager _serviceManager;

        public UserManager()
        {
            _serviceManager = SimpleIoc.Default.GetInstance<IServiceManager>();
        }

        public async Task<User> Authenticate(string email,string password)
        {
            var request = new AuthenticationRequest()
            {
                Email = email,
                Password = password
            };
            var user = await _serviceManager.Authenticate(request);
            if (user != null)
            {
                _serviceManager.SaveToken(user.Token);
            }
            return user;
        }
    }
}
