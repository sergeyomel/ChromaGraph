using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    public static class ConverterStringAdjMatrix
    {
        public static Graph GetGraph(List<List<string>> strAdjMatrix)
        {
            var graph = new Graph();
            foreach (var item in strAdjMatrix)
                graph.AddVertex();
            var countVertex = strAdjMatrix.Count;

            for (int row = 0; row < countVertex; row++)
            {
                var startVert = graph.GetVertex(row + 1);
                for (int col = 0; col < countVertex; col++)
                {
                    if (Convert.ToInt16(strAdjMatrix[row][col]) == 1)
                        graph.AddVConnector(startVert, graph.GetVertex(col + 1));
                }
            }

            return graph;
        }
    }
}
