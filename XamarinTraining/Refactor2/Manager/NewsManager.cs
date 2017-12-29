﻿using GalaSoft.MvvmLight.Ioc;
using Refactor2.Model;
using Refactor2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Manager
{
	public class NewsManager : BaseManager
	{
		public async Task<List<News>> GetNews()
		{
			return await _serviceManager.GetNews();
		}
	}
}
