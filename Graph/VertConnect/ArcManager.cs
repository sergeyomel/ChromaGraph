using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    internal class ArcManager : VCManager
    {
        internal ArcManager() : base() { }

        internal override VertexConnector AddConnector(Vertex start, Vertex end, bool IsBuff = false)
        {
            return new Arc(start, end, IsBuff);
        }
    }
}
