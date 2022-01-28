using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    internal class VManager
    {
        private int countVertex;
        private int currentIDVertex;

        internal VManager()
        {
            countVertex = 0;
            currentIDVertex = 0;
        }

        internal Vertex AddVertex()
        {
            countVertex += 1;
            currentIDVertex += 1;
            return new Vertex(currentIDVertex);
        }

        internal void RemoveVertex(Vertex vertex)
        {
            if (vertex.GetID() == currentIDVertex)
                currentIDVertex -= 1;
            countVertex -= 1;
            if (countVertex == 0)
                currentIDVertex = 0;
        }
    }
}
