using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GraphLib
{
    public class Vertex: IComparable<Vertex>
    {
        private int ID;

        public Vertex(int id)
        {
            ID = id;
        }

        public int GetID() => ID;

        public bool Equal(Vertex v)
        {
            if (v.GetID() == ID)
                return true;
            return false;
        }

        public int CompareTo([AllowNull] Vertex other)
        {
            if (this.GetID() < other.GetID()) return -1;
            if (this.GetID() > other.GetID()) return 1;
            return 0;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
        
    }
}
