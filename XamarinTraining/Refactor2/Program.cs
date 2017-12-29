using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Refactor2.Implementation;
using Refactor2.Manager;
using Refactor2.Service;
using Refactor2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var application = new ApplicationClient();
            application.Launch();
            Console.Read();
        }

        public class ApplicationClient
        {
            public void Launch()
            {
                Console.WriteLine("Application Launched");
                Register();
                var loginForm = new LoginForm();
                loginForm.Show();
            }

            private void Register()
            {
                var serviceManager = new ApplicationServiceManager("https://ft-ductuu138.oraclecloud2.dreamfactory.com/", new AppLoadingProgressor(), new AppNetworkDetector());

                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<IServiceManager>(() => serviceManager);
            }
        }

        public class LoginForm
        {
            public async void Show()
            {
                Console.WriteLine("Login Form Showed");
                var userManager = new UserManager();
                var viewModel = new LoginViewModel(userManager);
                Console.WriteLine("Input to Login");
                Console.Write("Email:");
                viewModel.Email = Console.ReadLine();
                Console.Write("Password:");
                viewModel.Password = Console.ReadLine();
                await viewModel.Login(HandleLoginSuccess);
            }

            private void HandleLoginSuccess()
            {
                var mainForm = new MainForm();
                mainForm.Show();
            }
        }

        public class MainForm
        {
            public async void Show()
            {
                Console.WriteLine("Main Form Showed");
                var mainViewModel = new MainViewModel(new NewsManager());
                await mainViewModel.GetNews();
            }
        }
    }
}
