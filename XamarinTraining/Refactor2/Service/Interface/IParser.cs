using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Refactor2.Service
{
    public interface IParser
	{
		Task<T> DeserializeObject<T>(HttpContent content);
		HttpContent CreateRequestBodyContent(object bodyObject);
	}
}
