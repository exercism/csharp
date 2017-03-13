using System;
using System.Linq;
using Humanizer;

namespace Generators.Exercises
{
    public class LeapExercise : Exercise
    {
        public LeapExercise() : base("leap")
        {
        }

        public override TestClass CreateTestClass(CanonicalData canonicalData)
        {
            return new TestClass
            {
                ClassName = "Leap",
                TestMethods = canonicalData.Cases.Select(CreateTestMethod).ToArray()
            };
        }

        private static TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase, int index)
        {
            var year = Convert.ToInt32(canonicalDataCase.Input);
            var isTrue = Convert.ToBoolean(canonicalDataCase.Expected);

            return new TestMethod
            {
                Index = index,
                MethodName = canonicalDataCase.Description.Replace(":", " is").Transform(To.TestMethodName),
                Body =  $"Assert.{isTrue}(Year.IsLeap({year}));"
            };
        }
    }
}