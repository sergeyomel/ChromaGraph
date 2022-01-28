using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Genetic.JSON
{
    public static class JSONReader
    {
        private static string path = Path.Combine(Environment.CurrentDirectory+"\\JSONINFO.txt");

        public static List<Model> Read()
        {
            if (!File.Exists(path))
                return null;

            var lModel = new List<Model>();

            using(var stream = new StreamReader(path))
            {
                while (!stream.EndOfStream)
                {
                    string str = stream.ReadLine();
                    lModel.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Model>(str));
                }
            }

            return lModel;

        }
    }
}
