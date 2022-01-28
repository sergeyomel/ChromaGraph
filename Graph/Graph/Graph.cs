using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GraphLib
{
    public class Graph
    {
        private Dictionary<Vertex, List<VertexConnector>> graph;
        private TypeGraph typeGraph;

        private VCManager VertConnectManager;
        private VManager VertManager;

        public List<List<int>> EvaluationMatrix;

        public Graph()
        {
            graph = new Dictionary<Vertex, List<VertexConnector>>();
            typeGraph = TypeGraph.Undirected;

            VertConnectManager = new EdgeManager();
            VertManager = new VManager();

            EvaluationMatrix = new List<List<int>>();
        }

        public Dictionary<Vertex, List<VertexConnector>> GetGraph() => graph;
        public TypeGraph GetTypeGraph() => typeGraph;
        public Vertex GetLastVertex() => graph.ElementAt(graph.Keys.Count() - 1).Key;
        public Vertex GetVertex(int id)
        {
            foreach (var key in graph.Keys.ToList())
                if (key.GetID() == id)
                    return key;
            return null;
        }

        public Vertex AddVertex()
        {
            var vertex = VertManager.AddVertex();
            graph.Add(vertex, new List<VertexConnector>());
            return vertex;
        }
        public void RemoveVertex(Vertex v)
        {
            if (!graph.ContainsKey(v))
                return;

            graph.Remove(v);
            VertManager.RemoveVertex(v);
            foreach(var key in graph.Keys.ToList())
            {
                var buffVertConnector = new List<VertexConnector>();
                foreach (var vc in graph[key])
                    if (!vc.ContainVertex(v))
                        buffVertConnector.Add(vc);
                graph[key] = buffVertConnector;
            }
        }

        public VertexConnector ContainVertConnector(Vertex start, Vertex end)
        {
            var buffVertConnector = new VertexConnector(start, end);
            foreach (var key in graph.Keys.ToList())
            {
                foreach (var vc in graph[key])
                    if (vc.Equal(buffVertConnector))
                        return vc;
            }
            return null;
        }
        public VertexConnector AddVConnector(Vertex start, Vertex end) 
        {
            var resContain = ContainVertConnector(start, end);
            if(resContain != null)
                return null;
            else {
                var connector = VertConnectManager.AddConnector(start, end, false);
                graph[start].Add(connector);
                if (typeGraph == TypeGraph.Undirected)
                    graph[end].Add(VertConnectManager.AddConnector(end, start, true));
                return connector;
            }
        }
        public void RemoveVConnector(VertexConnector vc) 
        {
            foreach (var key in graph.Keys.ToList())
            {
                if (graph[key].Contains(vc))
                {
                    graph[key].Remove(vc);
                    if (typeGraph == TypeGraph.Directed)
                    {
                        var reversVC = ContainVertConnector(vc.GetEndV(), vc.GetStartV());
                        graph[vc.GetEndV()].Remove(reversVC);
                    }
                    return;
                }
            }
        }

        private void ReplaceVCManager()
        {
            if (VertConnectManager.GetType() == typeof(EdgeManager))
                VertConnectManager = new ArcManager();
            else
                VertConnectManager = new EdgeManager();
        }
        private void ConvertUndirectToDirect()
        {
            foreach (var key in graph.Keys.ToList())
            {
                var buffVertConnector = new List<VertexConnector>();
                foreach (var connector in graph[key])
                {
                    if (!connector.IsBuff)
                        buffVertConnector.Add(VertexConnector.ConvertConnector(connector));
                }
                graph[key] = buffVertConnector;
            }
        }
        private void ConvertDirectToUndirect()
        {
            var buffGraph = new Dictionary<Vertex, List<VertexConnector>>();
            foreach (var key in graph.Keys.ToList())
                buffGraph.Add(key, new List<VertexConnector>());
            foreach (var key in graph.Keys.ToList())
                foreach (var connector in graph[key])
                    buffGraph[connector.GetEndV()].Add(VertConnectManager.AddConnector(connector.GetEndV(), connector.GetStartV(), true));
            foreach (var key in graph.Keys.ToList())
                graph[key].AddRange(buffGraph[key]);
        }

        public void ChangeTypeGraph()
        {
            typeGraph = typeGraph == TypeGraph.Directed ? TypeGraph.Undirected : TypeGraph.Directed;
            ReplaceVCManager();
            if (typeGraph == TypeGraph.Directed)
                ConvertUndirectToDirect();
            else
                ConvertDirectToUndirect();
        }

        /// <summary>
        /// Функция поиска смежных верин для данной вершины.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<Vertex> FindAdjacencyVertex(Vertex v)
        {
            var lAdjVertex = graph[v].Select(item => item.ReverseVertex(v)).ToList();
            if (typeGraph == TypeGraph.Undirected)
                return lAdjVertex;
            var buffAdjVertex = lAdjVertex
                                            .Select(vertex => graph[vertex]
                                            .Select(connector => connector.ReverseVertex(vertex))
                                            .ToList())
                                            .ToList();
            foreach (var item in buffAdjVertex)
                lAdjVertex.AddRange(item);

            return lAdjVertex.Distinct().ToList();
        }

        /// <summary>
        /// Функция просчёта оценочной матрицы.
        /// </summary>
        public void CalculationEvaMatrix()
        {
            int numVert = 0;
            int size = graph.Keys.Count;
            EvaluationMatrix = new List<List<int>>();
            for (int index = 0; index < size; index++)
                EvaluationMatrix.Add(new List<int>());

            foreach(var rVert in graph.Keys)
            {
                foreach(var cVert in graph.Keys)
                {
                    var localDegrVert = graph[rVert].Count();
                    var localDegcVert = graph[cVert].Count();
                    var sv = FindAdjacencyVertex(rVert).Contains(cVert) ? 0 : (int)(0.3 * size);
                    EvaluationMatrix[numVert].Add(localDegrVert + localDegcVert + sv);
                }
                numVert++;
            }

            for (int index = 0; index < graph.Keys.Count(); index++)
                EvaluationMatrix[index][index] = 0;

        }

        public override string ToString()
        {
            var sb = new StringBuilder("");
            foreach(var key in graph.Keys)
            {
                sb.Append(key+" |");
                foreach (var vc in graph[key])
                    sb.Append(vc.ToString()+" ");
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }
}
