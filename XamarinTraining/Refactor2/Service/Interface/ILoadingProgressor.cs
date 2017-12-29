using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service
{
    public interface ILoadingProgressor
    {
        void ShowLoadingProgress();

        void HideLoadingProgress();
    }
}
