using System.Collections.Generic;
using System.IO;
using System.Linq;
using Generators.Output;
using Newtonsoft.Json;

namespace Generators.Input
{
    public static class TrackConfigFile
    {
        private const string ConfigFilePath = "../config.json";

        public static IEnumerable<ConfigExercise> GetExercises()
        {
            var jsonContents = File.ReadAllText(ConfigFilePath);
            var config = JsonConvert.DeserializeObject<Config>(jsonContents);
            return config.Exercises.OrderBy(x => x.Slug).ToArray();
        }

        private sealed class Config
        {
            public ConfigExercise[] Exercises { get; set; }
        }

        public class ConfigExercise
        {
            public string Slug { get; set; }
            public bool Deprecated { get; set; }
        }
    }
}