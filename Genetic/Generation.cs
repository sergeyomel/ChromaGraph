using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetic.Interface;

namespace Genetic
{
    /// <summary>
    /// Класс - поколение особей.
    /// </summary>
    public class Generation
    {
        internal List<Individual> lCurrentIndividInGeneration;
        internal List<Individual> lLastIndividGeneration;

        private int countIndivid;
        private int probabilityCrossover = 50;
        private int probabilityMutation = 50;
        private Random rnd = new Random();

        private Individual bestIndividInGeneration;

        internal ICrossing crossover;
        internal IMutation mutation;
        internal ISelect selector;

        public Generation(
            List<Individual> lIndivid,
            ICrossing crossover,
            IMutation mutation,
            ISelect selector)
        {
            lCurrentIndividInGeneration = new List<Individual>();
            lLastIndividGeneration = lIndivid;
            countIndivid = lIndivid.Count;
            bestIndividInGeneration = lIndivid[0];
            this.crossover = crossover;
            this.mutation = mutation;
            this.selector = selector;
        }

        public List<Individual> GetListIndividInGeneration() => lCurrentIndividInGeneration;
        public Individual GetBestIndividInGeneration() => bestIndividInGeneration;

        /// <summary>
        /// Функция нахождения пары для скрещивания с особью, не равная данной особи.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int ParentSecondIndex(int index)
        {
            int indexParent = index;
            while (indexParent == index)
                indexParent = rnd.Next(0, countIndivid);
            return indexParent;
        }

        /// <summary>
        /// Функция скрещивания.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private (Individual childOne, Individual childTwo) Crossover(int index)
        {
            int indexParentTwo = ParentSecondIndex(index);
            if (rnd.Next(0, 100) < probabilityCrossover)
            {
                var result = crossover.CrossingIndividual(lLastIndividGeneration[index], lLastIndividGeneration[indexParentTwo]);
                return (result.childOne, result.childTwo);
            }
            return (lLastIndividGeneration[index], null);
        }

        private (Individual mutIndividOne, Individual mutIndividTwo) Mutation(Individual individOne, Individual individTwo)
        {
            if(rnd.Next(0, 100) < probabilityMutation)
            {
                individOne =  mutation.MutatingIndividual(individOne) ?? individOne;
                individTwo = individTwo != null ? mutation.MutatingIndividual(individTwo) : null;
                return (individOne, individTwo);
            }
            return (individOne, individTwo);
        }

        public void GenerationIndividual()
        {
            for(int index = 0; index < countIndivid; index++)
            {
                var resultCrossover = Crossover(index);
                var resultMutation = Mutation(resultCrossover.childOne, resultCrossover.childTwo);
                var bestIndivid = selector.SelectIndividual(lLastIndividGeneration[index], resultMutation.mutIndividOne);
                if (resultMutation.mutIndividTwo != null)
                    bestIndivid = selector.SelectIndividual(bestIndivid, resultMutation.mutIndividTwo);

                if (bestIndivid.TargetFunction() < bestIndividInGeneration.TargetFunction())
                    bestIndividInGeneration = bestIndivid;

                lCurrentIndividInGeneration.Add(bestIndivid);
            }
        }
        

    }
}
