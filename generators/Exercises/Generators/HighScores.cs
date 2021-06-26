using System.Collections.Generic;
using Exercism.CSharp.Output;

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
        }

        protected override void UpdateTestClass(TestClass testClass)
            => AddTestMethodForPersonalBest(testClass);

        protected override void UpdateNamespaces(ISet<string> namespaces)
            => namespaces.Add(typeof(List<int>).Namespace);

        private static void AddTestMethodForPersonalBest(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"[Fact(Skip = ""Remove this Skip property to run this test"")]
public void Latest_score_should_not_change_after_calling_personal_best()
{
    var sut = new HighScores(new List<int> { 20, 10, 30, 3, 2, 1 });
    Assert.Equal(30, sut.PersonalBest());
    Assert.Equal(1, sut.Latest());
}");

testClass.AdditionalMethods.Add(@"[Fact(Skip = ""Remove this Skip property to run this test"")]
public void Latest_score_should_not_change_after_calling_personal_top_three()
{
    var sut = new HighScores(new List<int> { 20, 100, 30, 90, 2, 70 });
    Assert.Equal(new List<int> { 100, 90, 70 }, sut.PersonalTopThree());
    Assert.Equal(70, sut.Latest());
}");
        }
    }
}
