using Refactor2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Implementation
{
    public class AppLoadingProgressor : ILoadingProgressor
    {
        public void HideLoadingProgress()
        {
            Console.WriteLine("Hide Loading");
        }

        public void ShowLoadingProgress()
        {
            Console.WriteLine("Show Loading");
        }
    }
}
