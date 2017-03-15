using System.Linq;
using Humanizer;

namespace Generators.Exercises
{
    public abstract class Exercise
    {
        protected Exercise(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public TestClass CreateTestClass(CanonicalData canonicalData)
        {
            return new TestClass
            {
                ClassName = Name.Transform(To.TestClassName),
                TestMethods = canonicalData.Cases.Select(CreateTestMethod).ToArray()
            };
        }
        protected abstract TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase, int index);
    }
}