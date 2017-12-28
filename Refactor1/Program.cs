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
                Console.WriteLine("Android Login Form");
                await HandleLogin();
            }
        }

        public class iOSClient
        {
            public async void RunLoginForm()
            {             
                Console.WriteLine("iOS Login Form");
                await HandleLogin();
            }
        }

        public static async Task HandleLogin()
        {
            var userManager = new UserManager(new LoginAuth());
            var viewModel = new LoginViewModel(userManager);

            Console.Write("Email:");
            viewModel.Email = Console.ReadLine();
            Console.Write("Password:");
            viewModel.Password = Console.ReadLine();
            await viewModel.Login();
        }         
    }
}
