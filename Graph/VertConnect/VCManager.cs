using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    abstract internal class VCManager
    {
        protected int countVertexConnector;
        protected int currentIDVertexConnector;


        internal VCManager()
        {
            countVertexConnector = 0;
            currentIDVertexConnector = 0;
        }

        abstract internal VertexConnector AddConnector(Vertex start, Vertex end, bool IsBuff);

    }
}
