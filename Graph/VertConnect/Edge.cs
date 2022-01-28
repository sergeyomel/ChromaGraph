using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Представляет из себя ребро: соединение вершин 
    /// в ненаправленном графе.
    /// </summary>
    public class Edge: VertexConnector
    {
        public Edge(Vertex start, Vertex end, bool IsBuff = false):base(start, end, IsBuff){}

        public override string ToString()
        {
            return Start.ToString() + " <-> " + End.ToString();
        }
    }
}
