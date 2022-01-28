using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    public static class ExtendList
    {
        public static List<Vertex> Shuffle(this List<Vertex> lVert)
        {
            var rnd = new Random();
            var countVertex = lVert.Count;
            for (int count = 0; count < countVertex; count++)
            {
                var posOne = rnd.Next(0, countVertex);
                var posTwo = rnd.Next(0, countVertex);
                var buffVert = lVert[posOne];
                lVert[posOne] = lVert[posTwo];
                lVert[posTwo] = buffVert;
            }
            return lVert;
        }
    }
}
