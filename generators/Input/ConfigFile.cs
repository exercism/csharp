using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Generators.Input
{
    public static class ConfigFile
    {
        private const string ConfigFilePath = "../config.json";

        public static IEnumerable<string> GetExerciseNames()
        {
            var jsonContents = File.ReadAllText(ConfigFilePath);
            var config = JsonConvert.DeserializeObject<Config>(jsonContents);
            return config.Exercises.Select(exercise => exercise.Slug).OrderBy(x => x).ToArray();
        }

        private class Config
        {
            public ConfigExercise[] Exercises { get; set; }
        }

        private class ConfigExercise
        {
            public string Slug { get; set; }
        }
    }
}