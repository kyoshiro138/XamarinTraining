using Refactor1.Helper;
using Refactor1.Manager;
using Refactor1.Service;
using Refactor1.ViewModel;
using System;

namespace Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            client.RunLoginForm(new ServiceManager(new DroidHelper()));
            Console.Read();
        }

        public class Client
        {
            public async void RunLoginForm(ServiceManager serviceManager)
            {
                var userManager = new UserManager(serviceManager);
                var viewModel = new LoginViewModel(userManager);
                var deviceOS = (serviceManager.Helper is iOSHelper) ? "iOS" : "Android";
                Console.WriteLine($"{deviceOS} Login Form");
                Console.Write("Email:");
                viewModel.Email = Console.ReadLine();
                Console.Write("Password:");
                viewModel.Password = Console.ReadLine();
                await viewModel.Login();
            }
        }
    }
}
