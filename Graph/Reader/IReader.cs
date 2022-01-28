using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Reader
{
    public interface IReader
    {
        public List<List<string>> Read(string path);
    }
}
