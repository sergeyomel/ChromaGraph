using Genetic.Interface;
using GraphLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic.Crossover
{
    public class DoublePointCrossing : ICrossing
    {
        public (Individual childOne, Individual childTwo) CrossingIndividual(Individual individOne, Individual individTwo)
        {
            var rnd = new Random();
            var pointCrossOne = rnd.Next(0, individOne.Genome.Count/2);
            var pointCrossTwo = rnd.Next(individOne.Genome.Count/2, individOne.Genome.Count);
            while(pointCrossTwo <= pointCrossOne)
                pointCrossTwo = rnd.Next(individOne.Genome.Count / 2, individOne.Genome.Count);
            var lengthPartGenome = pointCrossTwo - pointCrossOne;

            //Выборка части геномов из середины генотипа особей
            var partOfGenomIndividOne = individOne.Genome.Skip(pointCrossOne).Take(lengthPartGenome);
            var partOfGenomIndividTwo = individOne.Genome.Skip(pointCrossOne).Take(lengthPartGenome);

            var fullGenome = new List<Vertex>(individOne.Genome);

            //Взятие части генотипа из первоначальных особей
            var newIndividOne = individOne.Genome.Take(pointCrossOne).ToList();
            var newIndividTwo = individTwo.Genome.Take(pointCrossOne).ToList();

            //Добавление к новым особям серединной части генотипа из первоначальных особей
            newIndividOne.AddRange(partOfGenomIndividTwo);
            newIndividTwo.AddRange(partOfGenomIndividOne);

            //Удаление повторяющихся вершин в геноме
            newIndividOne = ((IEnumerable<Vertex>)newIndividOne).Distinct().ToList();
            newIndividTwo = ((IEnumerable<Vertex>)newIndividTwo).Distinct().ToList();

            //Дополнение генотипа вершинами, ещё не встречаавшихся в нём
            newIndividOne.AddRange(fullGenome.Except(newIndividOne).ToList().Shuffle());
            newIndividTwo.AddRange(fullGenome.Except(newIndividTwo).ToList().Shuffle());

            return (
                new Individual(individOne.Graph, newIndividOne),
                new Individual(individOne.Graph, newIndividTwo)
                );
        }

        public override string ToString()
        {
            return "DOUBLE POINT";
        }
    }
}
