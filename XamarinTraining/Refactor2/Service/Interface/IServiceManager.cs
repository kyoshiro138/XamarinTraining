using Refactor2.Model;
using Refactor2.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service
{
    public interface IServiceManager
    {
        Task<User> Authenticate(AuthenticationRequest request);

        Task<List<News>> GetNews();

        void SaveToken(string token);
    }
}
