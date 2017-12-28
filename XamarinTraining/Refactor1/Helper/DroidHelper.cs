using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Helper
{
    public class DroidHelper : IHelper
    {
        public bool HasNetworkConnection()
        {
            return true;
        }

        public void HideLoadingProgress()
        {
            // TODO: Hide Progress Dialog
            Console.WriteLine("Done");
        }

        public void ShowLoadingProgress()
        {
            // TODO: Show Progress Dialog
            Console.Write("Loading...");
        }
    }
}
