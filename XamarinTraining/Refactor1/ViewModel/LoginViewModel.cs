using Refactor1.Manager;
using System;
using System.Threading.Tasks;

namespace Refactor1.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public UserManager _userManager;

        public LoginViewModel(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task Login()
        {
            if (!IsValid())
            {
                return;
            }
            var user = await _userManager.Authenticate(Email, Password);
            if (user != null)
            {
                Console.WriteLine($"{user.DisplayName} has signed in.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            return true;
        }
    }
}
