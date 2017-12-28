using Refactor1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor1.Service.Request;

namespace Refactor1.Service
{
    public interface IServiceManager
    {
        Task<User> Authenticate(AuthenticationRequest request);
    }
}
