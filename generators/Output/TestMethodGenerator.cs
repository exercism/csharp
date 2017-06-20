using System.Collections.Generic;
using Generators.Input;

namespace Generators.Output
{
    public abstract class TestMethodGenerator
    {
        public TestMethod Create(CanonicalDataCase canonicalDataCase, Exercise exercise)
        {
            CanonicalDataCase = canonicalDataCase;
            CanonicalData = exercise.CanonicalData;
            Configuration = exercise.Configuration;

            return new TestMethod { MethodName = TestMethodName, Body = Body };
        }

        protected abstract IEnumerable<string> Body { get; }

        protected CanonicalDataCase CanonicalDataCase { get; private set; }
        protected CanonicalData CanonicalData { get; private set; }
        protected ExerciseConfiguration Configuration { get; private set; }
        
        protected string TestMethodName => CanonicalDataCase.Description.ToTestMethodName();
        protected string TestedClassName => CanonicalData.Exercise.ToTestedClassName();
        protected string TestedMethodName => CanonicalDataCase.Property.ToTestedMethodName();

        protected object Input => ValueFormatter.Format(CanonicalDataCase.Input);
        protected object Expected => ValueFormatter.Format(CanonicalDataCase.Expected);
    }
}