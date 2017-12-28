using Refactor1.Model;
using Refactor1.Service;
using System.Threading.Tasks;

namespace Refactor1.Manager
{
    public class UserManager : IServiceManager
    {
        private readonly IServiceManager _serviceManager;

        public UserManager(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            return await _serviceManager.Authenticate(email, password);
        }
    }
}
