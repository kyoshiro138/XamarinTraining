using GalaSoft.MvvmLight.Ioc;
using Refactor2.Model;
using Refactor2.Service;
using Refactor2.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Manager
{
	public class UserManager : BaseManager
	{
		public async Task<User> Authenticate(string email, string password)
		{
			var request = new AuthenticationRequest()
			{
				Email = email,
				Password = password
			};
			return await _serviceManager.Authenticate(request);
		}

		public void SaveToken(string token)
		{
			_serviceManager.SaveToken(token);
		}
	}
}
