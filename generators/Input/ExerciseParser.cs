using System.Collections.Generic;
using System.Linq;

namespace Exercism.CSharp.Input
{
    internal record Exercise(string Name, IReadOnlyCollection<TestCase> TestCases);
    
    internal record TestCase(int Index, string Uuid, string Property, IReadOnlyDictionary<string, dynamic> Input,
        dynamic Expected, string Description, IReadOnlyCollection<string> DescriptionPath);
    
    internal class ExerciseParser
    {
        private readonly CanonicalDataJsonParser _canonicalDataJsonParser;
        private readonly TestsTomlParser _testsTomlParser;

        private ExerciseParser(CanonicalDataJsonParser canonicalDataJsonParser, TestsTomlParser testsTomlParser)
        {
            _canonicalDataJsonParser = canonicalDataJsonParser;
            _testsTomlParser = testsTomlParser;
        }

        public static ExerciseParser Create(Options options) =>
            new(CanonicalDataJsonParser.Create(options), new TestsTomlParser(options));

        public Exercise Parse(string exercise)
        {
            var allTestCases = _canonicalDataJsonParser.Parse(exercise);
            var enabledTests = _testsTomlParser.ParseEnabledTests(exercise);
            var enabledTestCases = allTestCases.Where(testCase => enabledTests.Contains(testCase.Uuid)).ToArray();

            return new Exercise(exercise, enabledTestCases);
        }
    }
}