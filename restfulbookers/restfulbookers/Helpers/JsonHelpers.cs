using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBookerTestFramework.Helpers
{
    public static class JsonHelpers
    {
        public static string SerializeToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeFromJson<T>(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
