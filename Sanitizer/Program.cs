namespace Sanitizer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        public string PathOfFileToSaintize = @".\SampleData\InsuranceTerms.json";
        public string DirtyFileText()
        {
            string fileContent = File.ReadAllText(PathOfFileToSaintize);
            return fileContent;
        }

        public static void Main(string[] args)
        {
            Program client = new Program();
            string jsonText = client.DirtyFileText();
            JObject data = JObject.Parse(jsonText);
            JObject modifiedData = new JObject();
            foreach (KeyValuePair<string, JToken> item in data)
            {
                string key = item.Key;
                Console.WriteLine(key);
                modifiedData.Add(key.Trim(), data[key]);
            }

            foreach (KeyValuePair<string, JToken> item in modifiedData)
            {
                string key = item.Key;
                Console.WriteLine(key);
            }
        }
    }
}
