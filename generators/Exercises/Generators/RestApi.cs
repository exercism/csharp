using Exercism.CSharp.Output;
using Newtonsoft.Json;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class RestApi : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForTested = true;
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariablesForConstructorParameters = true;

            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "database" };
            testMethod.Input["database"] = JsonConvert.SerializeObject(testMethod.Input["database"]["users"]);

            if (testMethod.Input.ContainsKey("payload"))
                testMethod.Input["payload"] = JsonConvert.SerializeObject(testMethod.Input["payload"]);

            testMethod.Expected =
                JsonConvert.SerializeObject(testMethod.Expected!.ContainsKey("users")
                    ? testMethod.Expected["users"]
                    : testMethod.Expected);
        }
    }
}