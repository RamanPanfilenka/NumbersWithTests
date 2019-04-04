using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Dal.Models;

namespace Dal.Helpers
{
    public class JsonHelper
    {
        public static string Serializer<T> (T model)
        {
            var json = JsonConvert.SerializeObject(model);
            return json;
        }

        public static T DeSerializer<T> (string json)
        {
            var model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }
    }
}
