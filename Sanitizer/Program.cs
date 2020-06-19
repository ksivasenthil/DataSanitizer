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
        public Pipeline SetupPipeline()
        {
            StringProcessor removeQuotes = new StringProcessor("&quot;", 0);
            StringProcessor removeStartingSpaces = new StringProcessor(@"^\s*\r\n\s*\b",1);
            StringProcessor removeTrailingSpaces = new StringProcessor(@"\b\s*\r\n\s*$",2);

            Pipeline sanitizeJsonKeys = new Pipeline();
            sanitizeJsonKeys.AddProcessor(removeQuotes);
            sanitizeJsonKeys.AddProcessor(removeStartingSpaces);
            sanitizeJsonKeys.AddProcessor(removeTrailingSpaces);

            return sanitizeJsonKeys;
        }
        public static void Main(string[] args)
        {
            Program client = new Program();
            string jsonText = client.DirtyFileText();
            JObject data = JObject.Parse(jsonText);
            JObject modifiedData = new JObject();
            Pipeline configuredPipeline = client.SetupPipeline();
            foreach (KeyValuePair<string, JToken> item in data)
            {
                string key = item.Key;
                Console.WriteLine(key);
                string sanitizedKey = configuredPipeline.Process(key);
                modifiedData.Add(sanitizedKey, data[key]);
            }

            foreach (KeyValuePair<string, JToken> item in modifiedData)
            {
                string key = item.Key;
                Console.WriteLine(key);
            }
        }
    }
}
