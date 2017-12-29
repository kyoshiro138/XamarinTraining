using Refactor2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Manager
{
    public class BaseManager
    {
        protected readonly IServiceManager ServiceManager;

        public BaseManager(IServiceManager serviceManager)
        {
            ServiceManager = serviceManager;
        }
    }
}
