using System.Collections.Generic;
using System.Linq;

namespace Generators.Output
{
    public abstract class TestMethodGenerator
    {
        public TestMethod Create(TestMethodData testMethodData)
        {
            TestMethodData = testMethodData;

            return new TestMethod
            {
                UsingNamespaces = UsingNamespaces,
                MethodName = TestMethodName,
                Body = Body
            };
        }

        protected TestMethodData TestMethodData { get; private set; }

        protected abstract IEnumerable<string> Body { get; }

        protected virtual ISet<string> UsingNamespaces => new HashSet<string>();

        protected string TestMethodName => TestMethodData.CanonicalDataCase.Description.ToTestMethodName();

        protected string TestedClassName => TestMethodData.CanonicalData.Exercise.ToTestedClassName();

        protected string TestedMethodName => TestMethodData.CanonicalDataCase.Property.ToTestedMethodName();

        protected object Input => FormatInputValue(TestMethodData.CanonicalDataCase.Input);
        
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
            TestMethodData.Options.ExpectedFormat == ExpectedFormat.Unformatted
                ? TestMethodData.CanonicalDataCase.Expected
                : FormatExpectedValue(TestMethodData.CanonicalDataCase.Expected);

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