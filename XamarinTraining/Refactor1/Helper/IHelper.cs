using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Helper
{
    public interface IHelper
    {
        void ShowLoadingProgress();
        void HideLoadingProgress();
        bool HasNetworkConnection();
    }
}
