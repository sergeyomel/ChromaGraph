using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GraphLib
{
    internal class EdgeManager: VCManager
    {
        private bool IsAdd = true;
        internal EdgeManager(): base(){}

        internal override VertexConnector AddConnector(Vertex start, Vertex end, bool IsBuff)
        {
            if (!IsAdd)
            {
                IsAdd = true;
                return new Edge(start, end, IsBuff);
            }
            IsAdd = false;
            countVertexConnector += 1;
            currentIDVertexConnector += 1;
            return new Edge(start, end, IsBuff);
        }
    }
}
