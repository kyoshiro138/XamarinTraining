using Refactor2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Implementation
{
    public class AppNetworkDetector : INetworkDetector
    {
        public bool HasNetworkConnection { get { return true; } }
    }
}
