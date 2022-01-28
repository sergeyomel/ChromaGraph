using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic.JSON.PatternHistogram
{
    public class DependenceTimeOfCrossing: IPattern
    {
        public List<string> signatureColumn = null;

        public List<Dictionary<double, List<double>>> GetData(List<Model> data)
        {
            var convertedData = new List<Dictionary<double, List<double>>>();

            if (data == null)
                return null;

            var lCountIndividual = data.GroupBy(item => item.CountIndividInPopulation).Select(item => item.Key).ToList();
            lCountIndividual.Sort();
            var lTypeCrossing = data.GroupBy(item => item.CrossoverType).Select(item => item.Key).ToList();
            lTypeCrossing.Sort();

            signatureColumn = new List<string>(lTypeCrossing.Select(item => item.ToString()));

            for (int indexVertex = 0; indexVertex < lCountIndividual.Count; indexVertex++)
            {
                var lValue = new List<double>();
                var lModelWithCounIndividual = data.Where(item => item.CountIndividInPopulation == lCountIndividual[indexVertex]);

                var lAverageTimeForCountIndividInPopulation = new List<double>();

                for (int indexIndivid = 0; indexIndivid < lTypeCrossing.Count; indexIndivid++)
                {
                    var lModelVertexCountIndivid = lModelWithCounIndividual
                                                    .Where(item => item.CrossoverType == lTypeCrossing[indexIndivid])
                                                    .Select(item => item.LeadTime);
                    var averageTime = 0.0;
                    if (lModelVertexCountIndivid.Count() != 0)
                        averageTime = Math.Round(lModelVertexCountIndivid.Select(item => item.TotalMilliseconds).Average(), 1);
                    lAverageTimeForCountIndividInPopulation.Add(averageTime);
                }

                var element = new Dictionary<double, List<double>> { { lCountIndividual[indexVertex], lAverageTimeForCountIndividInPopulation } };

                convertedData.Add(element);
            }

            return convertedData;
        }


    }
}
