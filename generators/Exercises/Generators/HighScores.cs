using System.Collections.Generic;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class HighScores : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "scores" };

            testMethod.Input["scores"] = new List<int>(testMethod.Input["scores"]);
            
            if (testMethod.Expected is IEnumerable<int>)
                testMethod.Expected = new List<int>(testMethod.Expected);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces) 
            => namespaces.Add(typeof(List<int>).Namespace);
    }
}