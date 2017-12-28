using System;

namespace Refactor1.Service
{
    public class iOSServiceManager : BaseServiceManager
    {
        #region iOS platform code
        protected override bool HasNetworkConnection()
        {
            // TODO: Check network connection
            return true;
        }

        protected override void HideLoadingProgress()
        {
            // TODO: Hide Progress Dialog
            Console.WriteLine("Done");
        }

        protected override void ShowLoadingProgress()
        {
            // TODO: Show Progress Dialog
            Console.Write("Loading...");
        }
        #endregion
    }
}
