using Genetic.Interface;
using System;

namespace Genetic.Mutation
{
    public class ThreePointMutation : IMutation
    {
        public Individual MutatingIndividual(Individual individ)
        {
            var countChromosome = individ.Genome.Count;
            var rnd = new Random();
            var pointOne = rnd.Next(0, countChromosome);
            var pointTwo = rnd.Next(0, countChromosome);
            var pointThree = rnd.Next(0, countChromosome);
            while (pointOne == pointTwo)
                pointTwo = rnd.Next(0, countChromosome);
            while (pointOne == pointThree || pointTwo == pointThree)
                pointThree = rnd.Next(0, countChromosome);

            var buffPointOne = individ.Genome[pointOne];
            var buffPointTwo = individ.Genome[pointTwo];
            var buffPointThree = individ.Genome[pointThree];
            individ.Genome[pointOne] = buffPointThree;
            individ.Genome[pointTwo] = buffPointOne;
            individ.Genome[pointThree] = buffPointTwo;

            return individ;
        }

        public override string ToString()
        {
            return "THREE POINT";
        }
    }
}
