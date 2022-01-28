using System;
using System.Collections.Generic;
using System.Text;

namespace Genetic.Interface
{
    public interface IMutation
    {
        public Individual MutatingIndividual(Individual individ);
    }
}
