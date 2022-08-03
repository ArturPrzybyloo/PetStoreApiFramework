using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiFramework.Utils
{
    public static class TestData
    {
        public static T Read<T>(string fileName)
        {
            var file = File.ReadAllText(fileName + ".json");
            return JsonConvert.DeserializeObject<T>(file);
        }
    }
}
