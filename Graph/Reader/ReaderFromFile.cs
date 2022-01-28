using GraphLib.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphLib
{
    public class ReaderFromFile : IReader
    {
        public List<List<string>> Read(string path)
        {
            var strGraph = "";
            using (var sr = new StreamReader(path))
                strGraph = sr.ReadToEnd();

            var splitRow = strGraph.Split('\n').ToList();
            splitRow.RemoveRange(0, 2);

            var lAdjVert = new List<List<string>>();
            foreach (var item in splitRow)
            {
                var lBuffRes = item.Split('|').ToList();
                lBuffRes = lBuffRes.Select(item => item.Trim()).ToList();
                lBuffRes.RemoveAt(0);
                lBuffRes.RemoveAt(lBuffRes.Count - 1);
                lAdjVert.Add(lBuffRes);
            }

            return lAdjVert;
        }

    }
}
