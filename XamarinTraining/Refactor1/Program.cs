using Refactor1.Manager;
using Refactor1.Service;
using Refactor1.ViewModel;
using System;
using System.Threading.Tasks;

namespace Refactor1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new iOSClient();
            client.RunLoginForm();
            Console.Read();
        }

        public class AndroidClient
        {
            public async void RunLoginForm()
            {
                var userManager = new UserManager(new DroidServiceManager());
                var viewModel = new LoginViewModel(userManager);
                Console.WriteLine("Android Login Form");
                await HandleLogin(viewModel);
            }
        }

        public class iOSClient
        {
            public async void RunLoginForm()
            {
                var userManager = new UserManager(new iOSServiceManager());
                var viewModel = new LoginViewModel(userManager);
                Console.WriteLine("iOS Login Form");
                await HandleLogin(viewModel);
            }
        }

        public static async Task HandleLogin(LoginViewModel viewModel)
        {
            Console.Write("Email:");
            viewModel.Email = Console.ReadLine();
            Console.Write("Password:");
            viewModel.Password = Console.ReadLine();
            await viewModel.Login();
        }

    }
}
