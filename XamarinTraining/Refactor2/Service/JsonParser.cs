using Newtonsoft.Json;
using Refactor2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service
{
    public class JsonParser : IParser
    {
        public T DeserializeObject<T>(string responseBody)
        {
           return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public string SerializeObject(object responseObject)
        {
            return JsonConvert.SerializeObject(responseObject);
        }
    }
}
