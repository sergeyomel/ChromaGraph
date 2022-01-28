using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic.JSON.PatternHistogram
{
    /// <summary>
    /// Зависимость времени выполнения просчёта поколений
    /// от количества вершин в графе и количестве
    /// особей в поколении.
    /// 
    /// Слева - время,
    /// Снизу - количество вершин, 
    /// Колонки - количестов особей в поколении.
    /// </summary>
    public class DependenceTimeOfVertex : IPattern
    {
        public List<string> signatureColumn = null;

        public List<Dictionary<double, List<double>>> GetData(List<Model> data)
        {
            var convertedData = new List<Dictionary<double, List<double>>>();

            if (data == null)
                return null;

            var lCountVertex = data.GroupBy(item => item.CountVertex).Select(item => item.Key).ToList();
            lCountVertex.Sort();
            var lCountIndividInPopulation = data.GroupBy(item => item.CountIndividInPopulation).Select(item => item.Key).ToList();
            lCountIndividInPopulation.Sort();

            signatureColumn = new List<string>(lCountIndividInPopulation.Select(item => item.ToString()));

            for (int indexVertex = 0; indexVertex < lCountVertex.Count; indexVertex++)
            {
                var lValue = new List<double>();
                var lModelWithVertex = data.Where(item => item.CountVertex == lCountVertex[indexVertex]);

                var lAverageTimeForCountIndividInPopulation = new List<double>();

                for (int indexIndivid = 0; indexIndivid < lCountIndividInPopulation.Count; indexIndivid++)
                {
                    var lModelVertexCountIndivid = lModelWithVertex
                                                    .Where(item => item.CountIndividInPopulation == lCountIndividInPopulation[indexIndivid])
                                                    .Select(item => item.LeadTime);
                    var averageTime = 0.0;
                    if(lModelVertexCountIndivid.Count() != 0)
                        averageTime = Math.Round(lModelVertexCountIndivid.Select(item => item.TotalMilliseconds).Average(), 1);
                    lAverageTimeForCountIndividInPopulation.Add(averageTime);
                }

                var element = new Dictionary<double, List<double>> { { lCountVertex[indexVertex], lAverageTimeForCountIndividInPopulation } };

                convertedData.Add(element);
            }

            return convertedData;
        }
    }
}
