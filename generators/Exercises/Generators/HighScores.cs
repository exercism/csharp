using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

using Exercism.CSharp.Output;

using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class HighScores : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "scores" };

            testMethod.Input["scores"] = new List<int>(testMethod.Input["scores"]);

            if (testMethod.Expected is IEnumerable<int>)
                testMethod.Expected = new List<int>(testMethod.Expected);

            if (testMethod.Scenarios.Contains("immutable"))
            {
                var beforeProperty = testMethod.Property.Substring(0, testMethod.Property.IndexOf("After", StringComparison.Ordinal)).Replace("Best", "PersonalBest").Replace("TopThree", "PersonalTopThree").Pascalize();
                var afterProperty = testMethod.Property.Substring(testMethod.Property.IndexOf("After", StringComparison.Ordinal) + 5).Replace("Best", "PersonalBest").Replace("TopThree", "PersonalTopThree").Pascalize();

                testMethod.Act = $"var _ = sut.{afterProperty}();";
                testMethod.TestedMethod = beforeProperty;
            }
        }

        protected override void UpdateNamespaces(ISet<string> namespaces) =>
            namespaces.Add(typeof(List<int>).Namespace!);
    }
}
