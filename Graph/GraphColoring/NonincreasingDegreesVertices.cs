using GraphLib.GraphColoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    public class NonincreasingDegreesVertices: AlgorithmColoring
    {
        /// <summary>
        /// Функция поиска стартовой вершины для начала раскраски новым цветом.
        /// </summary>
        /// <param name="lVisitedVertex"></param>
        /// <param name="lSort"></param>
        /// <returns></returns>
        private Vertex FindStartVertex(List<Vertex> lVisitedVertex, List<(Vertex v, int c)> lSort)
        {
            foreach (var item in lSort)
                if (!lVisitedVertex.Contains(item.v))
                    return item.v;
            return null;
        }

        

        /// <summary>
        /// Функция раскраски графа по неубыванию степеней вершин.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<List<Vertex>> NonIncDegreesVertices(Graph graph)
        {
            var lSortDegVertex = graph.GetGraph()
                .Select(item => (item.Key, item.Value.Count))
                .OrderByDescending(item => item.Count)
                .ThenBy(item => item.Key.GetID())
                .ToList();
            var lVisitedVertex = new List<Vertex>();
            var lColorVertex = new List<List<Vertex>>();

            while(lVisitedVertex.Count != lSortDegVertex.Count())
            {
                var startVertex = FindStartVertex(lVisitedVertex, lSortDegVertex);
                lVisitedVertex.Add(startVertex);
                var buffNewColor = new List<Vertex>() { startVertex };
                var lAdjStartVertex = graph.FindAdjacencyVertex(startVertex);
                foreach (var tuple in lSortDegVertex)
                {
                    var lAdjBuffVertex = graph.FindAdjacencyVertex(tuple.Key);
                    if(!lAdjStartVertex.Contains(tuple.Key) &&
                       !lVisitedVertex.Contains(tuple.Key) &&
                       lAdjBuffVertex.Intersect(buffNewColor).Count() == 0)
                    {
                        lVisitedVertex.Add(tuple.Key);
                        buffNewColor.Add(tuple.Key);
                    }
                }
                lColorVertex.Add(buffNewColor);
            }
            return lColorVertex;
        }

        /// <summary>
        /// Переопределение абстактной функции класса AlgorithmColoring
        /// для реализации алгоритма раскраски графа по неубыванию
        /// степеней вершин.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public override List<List<Vertex>> Coloring(Graph graph)
        {
            return NonIncDegreesVertices(graph);
        }
    }
}