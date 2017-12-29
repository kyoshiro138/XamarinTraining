using Refactor2.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.ViewModel
{
	class MainViewModel
	{
		private readonly NewsManager _newsManager;

		public MainViewModel(NewsManager newsManager)
		{
			_newsManager = newsManager;
		}

		public async Task GetNews()
		{
			var newsList = await _newsManager.GetNews();
			if (newsList != null && newsList.Count > 0)
			{
				Console.WriteLine($"{newsList.Count} news");
				foreach (var news in newsList)
				{
					Console.WriteLine($"Title: {news.Title}");
					Console.WriteLine($"Description: {news.Description}");
				}
			}
			else
			{
				Console.WriteLine("No News.");
			}
		}
	}
}
