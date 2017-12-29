using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Refactor2.Implementation;
using Refactor2.Manager;
using Refactor2.Service;
using Refactor2.Service.Interface;
using Refactor2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2
{
    public partial class Program
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
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<IParser, JsonParser>();
                SimpleIoc.Default.Register<IServiceManager, ApplicationServiceManager>();
                SimpleIoc.Default.Register<ILoadingProgressor, AppLoadingProgressor>();
                SimpleIoc.Default.Register<INetworkDetector, AppNetworkDetector>();
                SimpleIoc.Default.Register<NewsManager>();
                SimpleIoc.Default.Register<UserManager>();
                SimpleIoc.Default.Register<MainViewModel>();
                SimpleIoc.Default.Register<LoginViewModel>();
            }
        }

        public class LoginForm: BaseForm
        {
            public override async void Show()
            {
                base.Show();           
                var viewModel = ServiceLocator.Current.GetInstance<LoginViewModel>();
                Console.WriteLine("Input to Login");
                Console.Write("Email:");
                viewModel.Email = Console.ReadLine();
                Console.Write("Password:");
                viewModel.Password = Console.ReadLine();
                if (await viewModel.Login())
                    HandleLoginSuccess();
            }
            private void HandleLoginSuccess()
            {
                var mainForm = new MainForm();
                mainForm.Show();
            }
        }


        public class MainForm : BaseForm
        {
            public override async void Show()
            {
                base.Show();
                var mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
                await mainViewModel.GetNews();
            }
        }

        public class BaseForm //ViewModel??
        {
            public virtual void Show()
            {
                Console.WriteLine(this.GetType().Name + " Showed");
            }
        }
    }
}
