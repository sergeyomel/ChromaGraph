using System;
using System.IO;

namespace Genetic.JSON
{
    public static class JSONWriter
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "JSONINFO.txt");

        public static void Write(Population population)
        {
            var model = new Model(
                population.GetCrossover().ToString(),
                population.GetMutation().ToString(),
                population.GetSelector().ToString(),
                population.GetBestIndividInPopulation().Genome.Count,
                population.GetBestIndividInPopulation().ValueTargetFunction,
                population.GetCountIndividInGeneration(),
                population.GetCountBestGeneration(),
                population.GetCountGenerationPassed(),
                population.GetLeadTime()
            );

            var JSONpopulation = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            using (StreamWriter stream = File.AppendText(path))
                stream.WriteLine(JSONpopulation);
        }
    }
}
