using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Generators.Output;

namespace Generators.Input
{
    public static class ConfigFile
    {
        private const string ConfigFilePath = "../config.json";

        public static IEnumerable<ConfigExercise> GetExercises()
        {
            var jsonContents = File.ReadAllText(ConfigFilePath);
            var config = JsonConvert.DeserializeObject<Config>(jsonContents);
            return config.Exercises.OrderBy(x => x.Name).ToArray();
        }

        private class Config
        {
            public ConfigExercise[] Exercises { get; set; }
        }

        public class ConfigExercise
        {
            public string Name { get { return this.Slug.ToExerciseName(); } }
            public string Slug { get; set; }
            public bool Core { get; set; }
            public int Difficulty { get; set; }
            public string[] Topics { get; set; }
            public string Unlocked_By { get; set; }
            public string UUID { get; set; }
            public bool Deprecated { get; set; }
        }
    }
}