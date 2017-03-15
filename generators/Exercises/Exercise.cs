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
                TestMethods = canonicalData.Cases.Select((canonicalDataCase, index) => CreateTestMethod(canonicalData, canonicalDataCase, index)).ToArray()
            };
        }
        protected abstract TestMethod CreateTestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index);
    }
}