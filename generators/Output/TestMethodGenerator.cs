using System.Collections.Generic;
using System.Linq;
using Generators.Exercises;
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
        
        protected CanonicalDataCase CanonicalDataCase { get; private set; }
        protected CanonicalData CanonicalData { get; private set; }
        protected ExerciseConfiguration Configuration { get; private set; }

        protected abstract IEnumerable<string> Body { get; }

        protected string TestMethodName => CanonicalDataCase.Description.ToTestMethodName();

        protected string TestedClassName => CanonicalData.Exercise.ToTestedClassName();

        protected string TestedMethodName => CanonicalDataCase.Property.ToTestedMethodName();

        protected object Input => FormatInputValue(CanonicalDataCase.Input);
        
        protected object FormatInputValue(object val)
        {
            switch (val)
            {
                case IDictionary<string, object> dict:
                    return string.Join(", ", dict.Values.Select(FormatInputValue));
                case string s:
                    return $"\"{s.Replace("\n", "\\n").Replace("\t", "\\t").Replace("\r", "\\r")}\"";
                default:
                    return val;
            }
        }

        protected object Expected =>
            Configuration.ExpectedFormat == ExpectedFormat.Unformatted
                ? CanonicalDataCase.Expected
                : FormatExpectedValue(CanonicalDataCase.Expected);

        protected object FormatExpectedValue(object val)
        {
            switch (val)
            {
                case string s:
                    return $"\"{s}\"";
                case IEnumerable<string> enumerable:
                    return enumerable.Select(FormatExpectedValue);
                default:
                    return val;
            }
        }
    }
}