using System;
using System.Collections.Generic;
using System.Text;

namespace Genetic.Interface
{
    public interface ISelect
    {
        public Individual SelectIndividual(Individual individOne, Individual individTwo);
    }
}
