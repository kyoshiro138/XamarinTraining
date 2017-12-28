using Refactor1.Model;
using System.Threading.Tasks;

namespace Refactor1.Service
{
    public interface IServiceManager
    {
        Task<User> Authenticate(string email, string password);
    }
}
