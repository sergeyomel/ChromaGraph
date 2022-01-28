using GraphLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Genetic
{
    public class Individual
    {
        private int CurrentColor = 0;

        private Dictionary<Vertex, int> dColorVertex;
        public readonly Graph Graph;
        public List<Vertex> Genome;
        public int ValueTargetFunction = -1;

        public Individual(Graph graph, List<Vertex> genome)
        {
            Graph = graph;
            Genome = genome;
            dColorVertex = new Dictionary<Vertex, int>();
            foreach (var item in Genome)
                dColorVertex.Add(item, -1);
        }

        public Dictionary<Vertex, int> GetDColorVertex() => dColorVertex;

        /// <summary>
        /// Функция расчёта количества цветов для раскраски генома. 
        /// </summary>
        /// <returns></returns>
        public int PowerFunction()
        {
            CurrentColor = 0;
            dColorVertex[Genome.First()] = CurrentColor;

            foreach(var vertex in Genome.Skip(1))
            {
                var lAdjVertex = Graph.FindAdjacencyVertex(vertex);
                var lVertCurrentColor = dColorVertex
                    .Where(item => item.Value == CurrentColor)
                    .Select(item => item.Key)
                    .ToList();
                if (lAdjVertex.Intersect(lVertCurrentColor).Count() != 0)
                    CurrentColor++;
                dColorVertex[vertex] = CurrentColor;
            }
            CurrentColor += 1;

            return CurrentColor;
        }

        /// <summary>
        /// Функция расчёта значения условной целевой функции.
        /// </summary>
        /// <returns></returns>
        public int TargetFunction()
        {
            if(ValueTargetFunction == -1)
                ValueTargetFunction = PowerFunction(); //Math.Round((PowerFunction() * 1.0) / Genome.Count(), 5);
            return ValueTargetFunction;
        }

        public override string ToString()
        {
            return String.Join(" ", Genome.Select(item => item.ToString()));
        }

    }
}
