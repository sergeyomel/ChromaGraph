using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic.JSON.PatternHistogram
{
    public class DependenceTimeOfMutation : IPattern
    {
        public List<string> signatureColumn = null;

        public List<Dictionary<double, List<double>>> GetData(List<Model> data)
        {
            var convertedData = new List<Dictionary<double, List<double>>>();

            if (data == null)
                return null;

            var lCountIndividual = data.GroupBy(item => item.CountIndividInPopulation).Select(item => item.Key).ToList();
            lCountIndividual.Sort();
            var lTypeMutation = data.GroupBy(item => item.MutationType).Select(item => item.Key).ToList();
            lTypeMutation.Sort();

            signatureColumn = new List<string>(lTypeMutation.Select(item => item.ToString()));

            for (int indexVertex = 0; indexVertex < lCountIndividual.Count; indexVertex++)
            {
                var lValue = new List<double>();
                var lModelWithCountIndividual = data.Where(item => item.CountIndividInPopulation == lCountIndividual[indexVertex]);

                var lAverageTimeForCountIndividInPopulation = new List<double>();

                for (int indexIndivid = 0; indexIndivid < lTypeMutation.Count; indexIndivid++)
                {
                    var lModelVertexCountIndivid = lModelWithCountIndividual
                                                    .Where(item => item.MutationType == lTypeMutation[indexIndivid])
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
