using GalaSoft.MvvmLight.Ioc;
using Refactor2.Manager;
using Refactor2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        private readonly UserManager _userManager;

        public LoginViewModel(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task Login(Action onLoginSuccess)
        {
            if(!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                var user = await _userManager.Authenticate(Email, Password);
                if(user != null)
                {
                    Console.WriteLine($"{user.DisplayName} has signed in.");
                    onLoginSuccess?.Invoke();
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("Email and password are required.");
            }
        }
    }
}
