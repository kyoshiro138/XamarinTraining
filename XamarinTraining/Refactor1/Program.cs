using Refactor1.Manager;
using Refactor1.Service;
using Refactor1.Service.Request;
using Refactor1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new iOSClient();
            client.RunLoginForm();
            Console.Read();
        }

        public class AndroidClient : BaseClient
        {
            public AndroidClient() : base(new DroidLoadingImpl(),new DroidNetworkDetector())
            {
            }

            public async void RunLoginForm()
            {
                Console.WriteLine("Android Login Form");
                Console.Write("Email:");
                viewModel.Email = Console.ReadLine();
                Console.Write("Password:");
                viewModel.Password = Console.ReadLine();
                await viewModel.Login();
            }
        }

    
        public class iOSClient : BaseClient
        {
            public iOSClient() : base(new IOSLoadingImpl(), new IOSNetworkDetector())
            {
            }

            public async void RunLoginForm()
            {
                Console.WriteLine("iOS Login Form");
                Console.Write("Email:");
                viewModel.Email = Console.ReadLine();
                Console.Write("Password:");
                viewModel.Password = Console.ReadLine();
                await viewModel.Login();
            }
        }

        public class BaseClient
        {
            private IServiceManager _serviceManager;
            protected UserManager userManager;

            protected LoginViewModel viewModel;

            public BaseClient(ILoadingDialog loading, INetworkDetector network)
            {
                _serviceManager = new ServiceManager(loading, network);
                userManager = new UserManager(_serviceManager);

                viewModel = new LoginViewModel(userManager);
            }
        }
    }
}
