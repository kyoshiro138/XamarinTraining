using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Service.Request
{
    public interface ILoadingDialog
    {
       void ShowLoadingProgress();

       void  HideLoadingProgress();
    }
}
