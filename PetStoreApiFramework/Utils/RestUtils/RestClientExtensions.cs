﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace PetStoreApiFramework.Utils
{
    public static class RestClientExtensions
    {
        public static RestResponse ExecuteWithLogs(this RestClient client, RestRequest request)
        {
            var response = client.Execute(request);
            var jsonLog = new JObject
            {
                {  "request", new JObject
                {
                    {"path", response.Request.Resource },
                    {"url", response.ResponseUri },
                    {"method", response.Request.Method.ToString()},
                    {"body", FormatJson(jsonString: Convert.ToString(response.Content))},
                }
                }
            };
            Console.WriteLine(jsonLog);
            return response;
        }

        private static JToken FormatJson(string jsonString)
        {
            if (jsonString.Length == 0)
            {
                return String.Empty;
            }

            try
            {
                if (jsonString[0] == '[')
                {
                    return JsonConvert.DeserializeObject<JArray>(jsonString);
                } else
                {
                    return JsonConvert.DeserializeObject<JObject>(jsonString);
                }
            }
            catch (JsonReaderException)
            {
                return jsonString;
            }
            catch (JsonSerializationException)
            {
                return jsonString;
            }
        }
    }
}