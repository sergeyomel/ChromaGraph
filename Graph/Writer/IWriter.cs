using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Writer
{
    public interface IWriter
    {
        public void Write(Graph graph);
    }
}
