using System.Collections.Generic;
using System.Linq;
using Humanizer;

namespace Generators.Exercises
{
    public abstract class Exercise
    {
        private static readonly BooleanTestMethodGenerator BooleanTestMethodGenerator = new BooleanTestMethodGenerator();
        private static readonly EqualityTestMethodGenerator EqualityTestMethodGenerator = new EqualityTestMethodGenerator();

        protected Exercise(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public TestClass CreateTestClass(CanonicalData canonicalData) => new TestClass
        {
            ClassName = Name.Transform(To.TestClassName),
            TestMethods = CreateTestMethods(canonicalData).ToArray()
        };
        
        private IEnumerable<TestMethod> CreateTestMethods(CanonicalData canonicalData)
            => canonicalData.Cases.Select((canonicalDataCase, index) => CreateTestMethod(new TestMethodData 
                { 
                    CanonicalData = canonicalData, 
                    CanonicalDataCase = canonicalDataCase, 
                    Index = index
                }));
        protected abstract TestMethod CreateTestMethod(TestMethodData testMethodData);

        protected TestMethod CreateBooleanTestMethod(TestMethodData testMethodData) 
            => BooleanTestMethodGenerator.Create(testMethodData);

        protected TestMethod CreateEqualityTestMethod(TestMethodData testMethodData) 
            => EqualityTestMethodGenerator.Create(testMethodData);
    }
}