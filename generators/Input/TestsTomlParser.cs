using System.Collections.Generic;
using System.IO;
using System.Linq;

using Tomlyn;
using Tomlyn.Syntax;

namespace Exercism.CSharp.Input
{
    internal class TestsTomlParser
    {
        private readonly Options _options;

        public TestsTomlParser(Options options) => _options = options;

        public HashSet<string> ParseEnabledTests(string exercise)
        {
            static bool IncludeMissingOrTrue (TableSyntaxBase table)
            {
                var includeKeyValue = table.Items.FirstOrDefault(item => item.Key.ToString().Trim() == "include");
                return includeKeyValue == null || includeKeyValue.Value.ToString().Trim() == "true";
            }

            var toml = ParseTestsToml(exercise);
            return toml.Tables
                .Where(IncludeMissingOrTrue)
                .Select(table => table.Name.ToString())
                .ToHashSet();
        }

        private DocumentSyntax ParseTestsToml(string exercise) =>
            Toml.Parse(File.ReadAllText(TestsTomlPath(exercise)));

        private string TestsTomlPath(string exercise) =>
            Path.Combine(_options.PracticeExercisesDir, exercise, ".meta", "tests.toml");
    }
}