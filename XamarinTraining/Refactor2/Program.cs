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
                var loginForm = new LoginForm(()=>
                {
                    var mainForm = new MainForm();
                    mainForm.Show();
                });
                loginForm.Show();
            }

            private void Register()
            {
                var serviceManager = new ApplicationServiceManager(new AppLoadingProgressor(), new AppNetworkDetector());

                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<IServiceManager>(() => serviceManager);
            }
        }

        public class LoginForm
        {
            private Action _onLoginSuccess;

            public LoginForm(Action onLoginSuccess)
            {
                _onLoginSuccess = onLoginSuccess;
            }

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
                _onLoginSuccess?.Invoke();
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
