using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Input
{
    internal record CanonicalData(string Exercise, IReadOnlyCollection<CanonicalDataCase> Cases);
    
    internal record CanonicalDataCase(int Index, string Property, IReadOnlyDictionary<string, dynamic> Input,
        dynamic Expected, string Description, IReadOnlyCollection<string> DescriptionPath);
    
    internal class CanonicalDataParser
    {
        private readonly Options _options;

        private CanonicalDataParser(Options options) => _options = options;

        public static CanonicalDataParser Create(Options options)
        {
            var propSpecsRepository = new PropSpecsRepository(options);
            propSpecsRepository.SyncToLatest();

            return new CanonicalDataParser(options);
        }

        public CanonicalData Parse(string exercise)
        {   
            var canonicalDataJson = ParseCanonicalData(exercise);
            var exerciseName = canonicalDataJson.Value<string>("exercise");
            var canonicalDataCases = CanonicalDataCaseParser.Parse((JArray)canonicalDataJson["cases"]);

            return new CanonicalData(exerciseName, canonicalDataCases);
        }

        private JObject ParseCanonicalData(string exercise) =>
            JObject.Parse(File.ReadAllText(ExerciseCanonicalDataPath(exercise)));

        private string ExerciseCanonicalDataPath(string exercise) =>
            Path.Combine(_options.ProbSpecsDir, "exercises", exercise, "canonical-data.json");
    }
}