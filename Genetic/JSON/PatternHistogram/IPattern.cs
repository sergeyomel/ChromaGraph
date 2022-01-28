using System;
using System.Collections.Generic;
using System.Text;

namespace Genetic.JSON.PatternHistogram
{
    public interface IPattern
    {
        public List<Dictionary<double, List<double>>> GetData(List<Model> data);
    }
}
