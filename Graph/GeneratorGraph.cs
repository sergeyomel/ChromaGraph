using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GraphLib
{
    public static class GeneratorGraph
    {
        private static Random rnd = new Random(); 

        private static int GetPairVertex(int id, int countVertex)
        {
            var rnd = new Random();
            int idPairVertex = rnd.Next(1, countVertex);
            while (idPairVertex == id)
                idPairVertex = rnd.Next(1, countVertex);
            return idPairVertex;
        }

        private static List<Vertex> BFS(Graph graph)
        {
            var currentGraph = graph.GetGraph();
            var qVertex = new List<Vertex>();
            var lVisitedVertex = new List<Vertex>();

            qVertex.Add(currentGraph.Keys.ToList()[rnd.Next(0, currentGraph.Keys.Count)]);
            while(qVertex.Count != 0)
            {
                var currentVertex = qVertex.First(); qVertex.RemoveAt(0);
                if(!lVisitedVertex.Contains(currentVertex))
                    lVisitedVertex.Add(currentVertex);
                var lAdjCurrentVertex = graph.FindAdjacencyVertex(currentVertex);
                var lNonVisitedAdjVertex = lAdjCurrentVertex.Except(lAdjCurrentVertex.Intersect(lVisitedVertex)).ToList();
                qVertex.AddRange(lNonVisitedAdjVertex);
                lVisitedVertex.AddRange(lNonVisitedAdjVertex);
            }

            var result = currentGraph.Keys.ToList().Except(lVisitedVertex).ToList();
            return result;
        }

        /// <summary>
        /// Метод проверки графа на полносвязность.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool IsConnectedGraph(Graph graph)
        {
            if (BFS(graph).Count() == 0)
                return true;
            return false;
        }

        private static Graph ExpandingGraph(Graph graph)
        {
            var currentGraph = graph.GetGraph();
            var lNonVisitedVertex = BFS(graph);

            var lVisitedVertex = currentGraph.Keys.ToList().Except(lNonVisitedVertex).ToList();
            for (int index = 0; index < lNonVisitedVertex.Count; index++)
            {
                var startVertex = lVisitedVertex[rnd.Next(0, lVisitedVertex.Count)];
                var endVertex = lNonVisitedVertex[index];
                graph.AddVConnector(startVertex, endVertex);
            }

            return graph;
        }

        public static Graph Generate(int countVertex, int countConnector)
        {
            var graph = new Graph();
            for (int index = 0; index < countVertex; index++)
                graph.AddVertex();

            for (int index = 0; index < countConnector; index++)
            {
                var id = rnd.Next(1, countVertex+1);
                var startVertex = graph.GetVertex(id);
                var endVertex = graph.GetVertex(GetPairVertex(id, countVertex));
                graph.AddVConnector(startVertex, endVertex);
            }

            return ExpandingGraph(graph);
        }
    }
}