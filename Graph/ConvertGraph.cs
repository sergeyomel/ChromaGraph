using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    public static class ConvertGraph
    {
        private static List<VertexConnector> GetSortIndividualVC(Graph graph)
        {
            var lVertexConnector = new List<VertexConnector>();
            var dGraph = graph.GetGraph();
            foreach (var key in dGraph.Keys)
            {
                foreach (var item in dGraph[key])
                    if (!lVertexConnector.Contains(item))
                        lVertexConnector.Add(item);
            }
            lVertexConnector.Sort();
            return lVertexConnector;
        }
        private static List<Vertex> GetSortVertex(Graph graph)
        {
            var dGraph = graph.GetGraph();
            var lVertex = new List<Vertex>();
            foreach (var key in dGraph.Keys)
                lVertex.Add(key);
            lVertex.Sort();
            return lVertex;
        }

        public static List<List<int>> GetAdjancyMatrix(Graph graph)
        {
            var adjMtr = new List<List<int>>();
            var lVertex = graph.GetGraph().Keys.ToList();

            for (int firstV = 0; firstV < lVertex.Count; firstV++)
            {
                adjMtr.Add(new List<int>());
                for (int secondV = 0; secondV < lVertex.Count; secondV++)
                {
                    if (graph.ContainVertConnector(lVertex[firstV], lVertex[secondV]) != null)
                        adjMtr[firstV].Add(1);
                    else
                        adjMtr[firstV].Add(0);
                }
            }
            return adjMtr;
        }

    }
}
