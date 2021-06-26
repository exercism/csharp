using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace Exercism.CSharp.Input
{
    internal static class TrackConfigFile
    {
        private static readonly string ConfigFilePath = Path.Combine("..", "config.json");

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

        internal class ConfigExercise
        {
            public string Slug { get; set; }
            public bool Deprecated { get; set; }
        }
    }
}