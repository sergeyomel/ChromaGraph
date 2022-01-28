using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genetic.JSON
{
    public class Model
    {
        [JsonProperty("cros")]
        public string CrossoverType { get; set; }

        [JsonProperty("mut")]
        public string MutationType { get; set; }

        [JsonProperty("select")]
        public string SelectorType { get; set; }

        [JsonProperty("cVert")]
        public int CountVertex { get; set; }

        [JsonProperty("cColor")]
        public int CountColor { get; set; }

        [JsonProperty("cIndivid")]
        public int CountIndividInPopulation { get; set; }

        [JsonProperty("rBestGen")]
        public int RepeatsBestGeneration { get; set; }

        [JsonProperty("cGenPas")]
        public int CountGenerationPassed { get; set; }

        [JsonProperty("lT")]
        public TimeSpan LeadTime { get; set; }

        public Model(string crossType,
                     string mutType,
                     string selectType,
                     int cVertex,
                     int cColor,
                     int cIndividInPop,
                     int repeatBestPop,
                     int cGeneratPass,
                     TimeSpan lTime)
        {
            CrossoverType = crossType;
            MutationType = mutType;
            SelectorType = selectType;
            CountVertex = cVertex;
            CountColor = cColor;
            CountIndividInPopulation = cIndividInPop;
            RepeatsBestGeneration = repeatBestPop;
            CountGenerationPassed = cGeneratPass;
            LeadTime = lTime;
        }

    }
}
