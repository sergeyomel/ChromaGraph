using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    public static class PrinterGraph
    {
        public static string AdjancyMatrix(Graph graph, List<List<int>> matrix)
        {
            var lVertex = graph.GetGraph().Keys.ToList();
            var sb = new StringBuilder("     ");

            foreach (var v in lVertex)
                sb.Append(String.Format("{0,5}", v));
            sb.Append("\n     ");
            for (int index = 0; index < lVertex.Count; index++)
                sb.Append("_____");
            sb.Append("\n");

            for(int index = 0; index < lVertex.Count; index++)
            {
                sb.Append(string.Format("{0,4}|", lVertex[index]));
                foreach (var item in matrix[index])
                    sb.Append(String.Format("{0,4}|", item));
                sb.Append("\n");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public static string EvaluationMatrix(Graph graph)
        {
            return AdjancyMatrix(graph, graph.EvaluationMatrix);
        }

    }
}
