using System.Collections.Generic;
using System.Linq;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Allergies : Exercise
    {
        public Allergies()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                if (canonicalDataCase.Property == "allergicTo")
                {
                    canonicalDataCase.Property = "IsAllergicTo";
                }
                else if (canonicalDataCase.Property == "list")
                { 
                    canonicalDataCase.Expected = ((JArray) canonicalDataCase.Expected).Values<string>();
                    canonicalDataCase.UseVariableForExpected = true;
                }

                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["score"] = canonicalDataCase.Properties["score"]
                };
                canonicalDataCase.Input.Remove("score");
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
            }
        }

        protected override TestClass CreateTestClass()
        {
            var testClass = base.CreateTestClass();
            
            foreach (var testMethod in testClass.TestMethods.Where(x => x.GeneratedFrom.Property == "IsAllergicTo"))
                testMethod.Body = UpdateIsAllergicToTestMethod(testMethod);

            return testClass;
        }

        private static IEnumerable<string> UpdateIsAllergicToTestMethod(TestMethod testMethod)
        {
            var lines = testMethod.Body.ToList();
            lines.RemoveAt(lines.Count - 1);
            lines.AddRange(((JArray) testMethod.GeneratedFrom.Expected).Children().Select(CreateIsAllergicToAssertion));
            return lines;
        }

        private static string CreateIsAllergicToAssertion(JToken jToken)
        {
            var equalityMethod = jToken["result"].Value<bool>() ? "True" : "False";
            return $"Assert.{equalityMethod}(sut.IsAllergicTo({ValueFormatter.Format(jToken["substance"].Value<string>())}));";
        }
    }
}