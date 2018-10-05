using Exercism.CSharp.Output;
using Newtonsoft.Json;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RestApi : GeneratorExercise
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
            {
                testMethod.Input["payload"] = JsonConvert.SerializeObject(testMethod.Input["payload"]);
            }

            if (testMethod.Expected.ContainsKey("users"))
            {
                testMethod.Expected = JsonConvert.SerializeObject(testMethod.Expected["users"]);
            }
            else
            {
                testMethod.Expected = JsonConvert.SerializeObject(testMethod.Expected);
            }
        }
    }
}