using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service.Interface
{
    public interface IRequestContent
    {
        HttpContent CreateRequestBodyContent(Object bodyObject);
    }

    public class RequestContentFromJson : IRequestContent
    {
        public HttpContent CreateRequestBodyContent(object bodyObject)
        {
            var bodyString = JsonConvert.SerializeObject(bodyObject);
            return new StringContent(bodyString, Encoding.UTF8, "application/json");
        }
    }

}
