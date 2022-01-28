using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Представляет из себя дугу: соединитель вершин
    /// в направленном графе.
    /// </summary>
    public class Arc: VertexConnector
    {
        public Arc(Vertex start, Vertex end, bool IsBuff) : base(start, end, false) { }

        public override string ToString()
        {
            return Start.ToString() + " -> " + End.ToString();
        }
    }
}
