using GalaSoft.MvvmLight.Ioc;
using Refactor2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Manager
{
	public abstract class BaseManager
	{
		protected readonly IServiceManager _serviceManager;

		public BaseManager()
		{
			_serviceManager = SimpleIoc.Default.GetInstance<IServiceManager>();
		}
	}
}
