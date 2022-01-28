using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GraphLib.Reader
{
    public class ReaderNatashaGraph : IReader
    {
        public List<List<string>> Read(string path)
        {
            var strGraph = "";
            using (var sr = new StreamReader(path))
                strGraph = sr.ReadToEnd();

            var splitRow = strGraph.Split('\n').ToList();

            var lAdjVert = new List<List<string>>();
            foreach (var item in splitRow)
            {
                var lBuffRes = item.Split(" ").ToList();
                lBuffRes = lBuffRes.Select(item => item.Trim()).ToList();
                lAdjVert.Add(lBuffRes);
            }

            return lAdjVert;
        }

    }
}
