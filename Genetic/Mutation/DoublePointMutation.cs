using System;
using Genetic.Interface;

namespace Genetic.Mutation
{
    public class DoublePointMutation : IMutation
    {
        public Individual MutatingIndividual(Individual individ)
        {
            var countChromosome = individ.Genome.Count;
            var rnd = new Random();
            var pointOne = rnd.Next(0, countChromosome);
            var pointTwo = rnd.Next(0, countChromosome);
            while(pointOne == pointTwo)
                pointTwo = rnd.Next(0, countChromosome);

            var buffPointOne = individ.Genome[pointOne];
            var buffPointTwo = individ.Genome[pointTwo];
            individ.Genome[pointOne] = buffPointTwo;
            individ.Genome[pointTwo] = buffPointOne;

            return individ;
        }

        public override string ToString()
        {
            return "DOUBLE POINT";
        }
    }
}
