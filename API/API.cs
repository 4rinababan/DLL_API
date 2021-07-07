using System;
using System.Net.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Net;
using Newtonsoft.Json;

namespace API
{
    public class API
    {
        public string postJson(string host, string json)
        {
            var result = string.Empty;
            var data = new JavaScriptSerializer().Deserialize<List<string>>(json);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(host);//local for test
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string output = JsonConvert.SerializeObject(json);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result.ToString();
        }

        public Array getJson(string host, string json)
        {
            var result = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(host);//local for test
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string output = JsonConvert.SerializeObject(json);
                streamWriter.Write(output);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result.ToArray();
        }
    }
}
