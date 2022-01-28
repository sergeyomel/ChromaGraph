using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GraphLib
{
    public class VertexConnector
    {
        public readonly bool IsBuff;
        protected Vertex Start;
        protected Vertex End;

        public VertexConnector(Vertex start, Vertex end, bool IsBuff = false)
        {
            Start = start;
            End = end;
            this.IsBuff = IsBuff;
        }

        public Vertex GetStartV() => Start;
        public Vertex GetEndV() => End;

        public static VertexConnector ConvertConnector(VertexConnector connector)
        {
            if (connector.GetType() == typeof(Arc))
                return new Edge(connector.GetStartV(), connector.GetEndV(), connector.IsBuff);
            if (connector.GetType() == typeof(Edge))
                return new Arc(connector.GetStartV(), connector.GetEndV(), connector.IsBuff);
            return null;
        }

        public virtual void Draw() { }
        
        public bool Equal(Vertex start, Vertex end)
        {
            if (start.Equal(Start) && end.Equal(End))
                return true;
            return false;
        }
        public bool Equal(VertexConnector vc)
        {
            return Equal(vc.GetStartV(), vc.GetEndV());
        }
        public bool ContainVertex(Vertex v)
        {
            if (Start.Equal(v) || End.Equal(v))
                return true;
            return false;
        }
        public Vertex ReverseVertex(Vertex v)
        {
            if (GetStartV().Equal(v))
                return GetEndV();
            if (GetEndV().Equal(v))
                return GetStartV();
            return null;
        }

        public override string ToString()
        {
            return Start.ToString() + " -> " + End.ToString();
        }

    }
}
