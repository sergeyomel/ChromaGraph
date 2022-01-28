using System;
using System.Linq;
using Genetic.Interface;
using GraphLib;
using System.Collections.Generic;

namespace Genetic.Crossover
{
    public class SinglePointCrossing : ICrossing
    {
        public (Individual, Individual) CrossingIndividual(Individual individOne, Individual individTwo)
        {
            var rnd = new Random();
            var pointCross = rnd.Next(0, individOne.Genome.Count);
            var fullGenome = new List<Vertex>(individOne.Genome);

            var newIndividOne = individTwo.Genome.Take(pointCross).ToList();
            var newIndividTwo = individOne.Genome.Take(pointCross).ToList();

            newIndividOne.AddRange(fullGenome.Except(newIndividOne).ToList().Shuffle());
            newIndividTwo.AddRange(fullGenome.Except(newIndividTwo).ToList().Shuffle());

            return (
                new Individual(individOne.Graph, newIndividOne),
                new Individual(individOne.Graph, newIndividTwo));
        }

        public override string ToString()
        {
            return "SINGLE POINT";
        }
    }
}
