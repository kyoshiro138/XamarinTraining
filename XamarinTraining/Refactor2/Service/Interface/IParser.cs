using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor2.Service.Interface
{
    public interface IParser
    {
        T DeserializeObject<T>(string responseBody);
        string SerializeObject(object responseObject);
    }
}
