using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service
{
	public abstract class BaseServiceManager
	{
		private string _baseUrl;
		private HttpClient _client;
		private ILoadingProgressor _loadingProgressor;
		private INetworkDetector _networkDetector;
		private IParser _parser;

		protected IParser Parser { get { return _parser; } }
		protected HttpClient Client { get { return _client; } }

		public BaseServiceManager(string baseUrl, ILoadingProgressor loadingProgressor, INetworkDetector networkDetector, IParser parser)
		{
			_client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
			_baseUrl = baseUrl;
			_loadingProgressor = loadingProgressor;
			_networkDetector = networkDetector;
			_parser = parser;
		}

		public async Task<HttpResponseMessage> InvokeService(HttpMethod method, string methodUrl, object bodyObject = null)
		{
			if (_networkDetector.HasNetworkConnection)
			{
				_loadingProgressor.ShowLoadingProgress();
				HttpResponseMessage responseMessage = null;
				try
				{
					var requestMessage = new HttpRequestMessage(method, _baseUrl + methodUrl);
					if (bodyObject != null)
					{
						requestMessage.Content = _parser.CreateRequestBodyContent(bodyObject);
					}
					responseMessage = await _client.SendAsync(requestMessage);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				_loadingProgressor.HideLoadingProgress();
				return responseMessage;
			}
			else
			{
				Console.WriteLine("No network connection.");
				return null;
			}
		}
	}
}
