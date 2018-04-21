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

        //SS: public static IEnumerable<string> GetExerciseNames()
        public static IEnumerable<ConfigExercise> GetExercises() //SS:Names()
        {
            var jsonContents = File.ReadAllText(ConfigFilePath);
            var config = JsonConvert.DeserializeObject<Config>(jsonContents);
            //SS: return config.Exercises.Select(exercise => exercise.Slug).OrderBy(x => x).ToArray();
            return config.Exercises.OrderBy(x => x.Slug).ToArray();
        }

        private class Config
        {
            public ConfigExercise[] Exercises { get; set; }
        }

        //ss:private class ConfigExercise
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
            //{
            //  "core": false,
            //  "difficulty": 10,
            //  "slug": "pov",
            //  "topics": [
            //    "graphs",
            //    "recursion",
            //    "searching"
            //  ],
            //  "unlocked_by": "markdown",
            //  "uuid": "a5794706-58d2-48f7-8aab-78639d7bce77"
            //},

        }
    }
}