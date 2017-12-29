using GalaSoft.MvvmLight.Ioc;
using Refactor2.Model;
using Refactor2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Manager
{
    public class NewsManager : BaseManager
    {
        public NewsManager(IServiceManager _serviceManager) : base(_serviceManager)
        {
        }

        public async Task<List<News>> GetNews()
        {
            return await ServiceManager.GetNews();
        }
    }
}
